using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState state;
    [SerializeField] public Player player;
    [SerializeField] protected int startingPlatform;
    [SerializeField] protected float xPawnOffset;
    [SerializeField] protected float minYSpawnPos;
    [SerializeField] protected float maxYSpawnPos;
    [SerializeField] protected Platform[] platformPrefabs;
    [SerializeField] protected CollectableItem[] collectableItems;
    [SerializeField] protected float halfCamSizeX;

    [SerializeField] protected Platform lastPlatformSpawned;
    public Platform LastPlatformSpawned { get => lastPlatformSpawned; set => lastPlatformSpawned = value; }

    [SerializeField] protected List<int> platformLandedIds;
    public List<int> PlatformLandedIds { get => platformLandedIds; set => platformLandedIds = value; }

    [SerializeField] private int score;
    public int Score { get => score;}

    public override void Awake()
    {
        MakeSingleton(false);
        platformLandedIds = new List<int>();
        halfCamSizeX = Helper.Get2DCamSize().x / 2;
    }
    public override void Start()
    {
        base.Start();
        state = GameState.Starting;
        Invoke("PlatformInit",0.5f);

        if (AudioController.Ins)
        {
            AudioController.Ins.PlayBackgroundMusic();
        }
    }

    public void PlayGame()
    {
        if (GUIManager.Ins)
        {
            GUIManager.Ins.ShowGameplay(true);
        }
        Invoke("PlayGameIvk", 1f);
    }

    protected void PlayGameIvk()
    {
        state = GameState.Playing;
        if (player)
        {
            player.Jump();
        }
    }

    protected virtual void PlatformInit()
    {
        lastPlatformSpawned = player.PlatformLanded;
        for(int i =0; i<startingPlatform; i++)
        {
            this.SpawnPlatform();
        }
    }

    public bool IsPlatformLanded(int id)
    {
        if (platformLandedIds ==null || platformLandedIds.Count <= 0) return false;
        return platformLandedIds.Contains(id);

    }

    public virtual void SpawnPlatform()
    {
        if (!player || platformPrefabs == null || platformPrefabs.Length <= 0) return;

        float spawnPosX = Random.Range(
            -(halfCamSizeX - xPawnOffset), (halfCamSizeX - xPawnOffset));
        float distanceOf2Plat = Random.Range(minYSpawnPos, maxYSpawnPos);

        float spawnPosY = lastPlatformSpawned.transform.position.y + distanceOf2Plat;

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);

        int randIndex = Random.Range(0, platformPrefabs.Length);
        var platformPre = platformPrefabs[randIndex];

        if (!platformPre) return;

        var platformClone = Instantiate(platformPre, spawnPos, Quaternion.identity);
        platformClone.IdPlatform = lastPlatformSpawned.IdPlatform + 1;
        lastPlatformSpawned = platformClone;
    }

    public void SpawnCollectable(Transform spawnPoint)
    {
        if (collectableItems == null || collectableItems.Length <= 0 || state != GameState.Playing) return;

        int randIdx = Random.Range(0, collectableItems.Length);

        var collectItem = collectableItems[randIdx];

        if (collectItem == null) return;

        float ranCheck = Random.Range(0f, 1f);
        if(ranCheck <= collectItem.spawnRate && collectItem.collectablePrefab)
        {
            var cClone = Instantiate(collectItem.collectablePrefab, spawnPoint.position, Quaternion.identity);

            cClone.transform.SetParent(spawnPoint);
        }
    }
    public void AddScore(int scoreToAdd)
    {
        if (state != GameState.Playing) return;
        score += scoreToAdd;
        Pref.bestScore = score;
        if (GUIManager.Ins)
        {
            GUIManager.Ins.UpdateScore(score);
        }
    }
}
