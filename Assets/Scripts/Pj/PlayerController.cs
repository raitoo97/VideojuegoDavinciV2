using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Vector2 movVector = Vector2.zero;
    private int movementVelocity;
    private Rigidbody2D rb;
    //Timer
    [SerializeField] float stunTime;
    float stunTimer;
    public bool stunned;
    private void Start()
    {
        movementVelocity = 10;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        OnMove();
    }
    private void Update()
    {
        RotateSprite();
        stunCooldown();
    }
    private void OnMove()
    {
        if (stunned) return;
        movVector = InputManager.instance.GetMovementPj();
        if (movVector == null) return;
        movVector.Normalize();
        rb?.MovePosition(rb.position + movVector * Time.fixedDeltaTime * movementVelocity);
    }
    private void RotateSprite()
    {
        if (movVector.x == 0 && movVector.y == 1)
        {
            AnimationController.Instance.ChangeAnimation(POSITION.UP);
        }
        if (movVector.x == 0 && movVector.y == -1)
        {
            AnimationController.Instance.ChangeAnimation(POSITION.DOWN);
        }
        if (movVector.x == 1 && movVector.y == 0)
        {
            AnimationController.Instance.ChangeAnimation(POSITION.RIGHT);
        }
        if (movVector.x == -1 && movVector.y == 0)
        {
            AnimationController.Instance.ChangeAnimation(POSITION.LEFT);
        }
    }
    public void TakeKnockback(Vector2 kb)
    {
        if (stunned) return;
        stunned = true;
        rb.AddForce(kb, ForceMode2D.Impulse);
    }
    #region Cooldown
    void stunCooldown()
    {
        if(!stunned) return;
        stunTimer += Time.deltaTime;
        if (stunTimer >= stunTime)
        {
            stunned = false;
            stunTimer = 0;
        }
    }
    #endregion
}
