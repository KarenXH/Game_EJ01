using UnityEngine;

public enum GameState
{
    Starting,
    Playing,
    Gameover,
}

public enum GameTag
{
    Platform,
    Player,
    LeftCorner,
    RightCorner,
    Collectable
}

public enum PrefKey
{
    BestSCore
}

[System.Serializable]
public class CollectableItem
{
    public Collectable collectablePrefab;
    [Range(0f,1f)]
    public float spawnRate;

}