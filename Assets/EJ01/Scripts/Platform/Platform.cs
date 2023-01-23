using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Transform collectSpawnPoint;   
    [SerializeField] protected Player player;
    [SerializeField] protected Rigidbody2D rb2D;

    [SerializeField] protected int idPlatform;
    public int IdPlatform { get => idPlatform; set => idPlatform = value; }

    protected virtual void Awake()
    {
        if (rb2D != null) return;
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        if (!GameManager.Ins) return;

        this.player = GameManager.Ins.player;

        if (collectSpawnPoint)
        {
            GameManager.Ins.SpawnCollectable(collectSpawnPoint);
        }
    }

    public virtual void PlatformAction()
    {

    }
}
