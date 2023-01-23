using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public bool canMoveLeft;
    [SerializeField] public bool canMoveRight;

    protected override void Start()
    {
        base.Start();
        float randCheck = Random.Range(0f, 1f);
        if (randCheck <= 0.5f)
        {
            canMoveLeft = true;
            canMoveRight = false;
        }else 
        {
            canMoveLeft = false;
            canMoveRight = true;
        }
    }

    private void FixedUpdate()
    {
        float curSpeed = 0;

        if (!rb2D) return;

        if (canMoveLeft)
        {
            curSpeed = -moveSpeed;
        }else if (canMoveRight)
        {
            curSpeed = moveSpeed;
        }

        rb2D.velocity = new Vector2(curSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.LeftCorner.ToString()))
        {
            canMoveLeft = false;
            canMoveRight = true;
        }else if (col.CompareTag(GameTag.RightCorner.ToString()))
        {
            canMoveLeft = true;
            canMoveRight = false;
        }
    }

}
