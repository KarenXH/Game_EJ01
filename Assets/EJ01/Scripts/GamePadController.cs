using UnityEngine;

public class GamePadController : Singleton<GamePadController>
{
    [SerializeField] protected bool isOnMobile;
    [SerializeField] public bool canMoveLeft;
    [SerializeField] public bool canMoceRight;

    public bool CanMoveLeft { get => canMoveLeft; set => canMoveLeft = value; }
    public bool CanMoceRight { get => canMoceRight; set => canMoceRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Update()
    {
        if (isOnMobile) return;

        canMoveLeft = Input.GetAxisRaw("Horizontal") < 0 ? true : false;
        canMoceRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }
}
