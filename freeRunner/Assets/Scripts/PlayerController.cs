using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private Animator myAnimator;

    //gound
    public bool grounded;
    public LayerMask whatIsGround;

    //speed
    public float moveSpeed;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    //jump
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;






    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            moveSpeed = moveSpeed * speedMultiplier;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
        }


        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        UserInputHandler();

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        myAnimator.SetFloat("Speed", moveSpeed);
        myAnimator.SetBool("Grounded", grounded);
    }

    void UserInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }
    }
}
