using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator anim;
    [SerializeField] protected bool facingRight = true;

    [SerializeField] protected GameObject dust;

    [SerializeField] protected float movingLimitX;
    public float MovingLimitX { get => movingLimitX; }

    [SerializeField] protected Platform platformLanded;
    public Platform PlatformLanded { get => platformLanded; set => platformLanded = value; }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        this.CheckFace();
        this.CheckJumpFall();
    }
    private void FixedUpdate()
    {
        this.MovingHandle();
    }

    protected virtual void CheckJumpFall()
    {
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);

        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("isFalling", false);
        }
    }
    protected virtual void CheckFace()
    {
        if (GamePadController.Ins.canMoceRight && !facingRight)
            this.Flip();
        else if (GamePadController.Ins.CanMoveLeft && facingRight)
            this.Flip();
    }

    protected virtual void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public virtual void Jump()
    {
        if (!GameManager.Ins || GameManager.Ins.state != GameState.Playing) return;

       
        if (!rb || rb.velocity.y > 0 || !platformLanded) return;
                

        if (platformLanded is BreakablePlatform)
        {
            platformLanded.PlatformAction();
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);


        anim.SetBool("isJumping", true);
        anim.SetBool("isFalling", false);
        if (AudioController.Ins)
        {
            AudioController.Ins.PlaySound(AudioController.Ins.jump);
        }
        Vector3 pos = new Vector3(transform.position.x, transform.position.y -0.3f, transform.position.z);
        Instantiate(dust, pos, Quaternion.identity);
    }

    protected virtual void MovingHandle()
    {
        if (!GamePadController.Ins || !rb || !GameManager.Ins || GameManager.Ins.state != GameState.Playing) return;

        if (GamePadController.Ins.CanMoveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (GamePadController.Ins.CanMoceRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        movingLimitX = (Helper.Get2DCamSize().x / 2) - 0.4f;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -movingLimitX, movingLimitX),
            transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Collectable.ToString()))
        {
            var collectable = col.GetComponent<Collectable>();
            if (collectable)
            {
                collectable.Trigger();
            }
        }


    }


}
