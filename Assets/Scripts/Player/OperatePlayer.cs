using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatePlayer : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 15f;
    private Vector2 jumpVector;
    private Transform transform;
    private Vector2 defaultPosition;
    [SerializeField]
    private float returnSpeed = 0.3f;
    private Vector2 returnVector;
    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;
    private Animator anim = null;
    private bool isGrounded;
    private bool isJumping = false;
    private bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {

        jumpVector = new Vector2(0f, jumpPower);
        returnVector = new Vector2(returnSpeed, 0);
        transform = gameObject.transform;
        defaultPosition = transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        if(rigidBody.gravityScale == 1)
        { rigidBody.gravityScale = 3; }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && (rigidBody.velocity.y == 0f))
        { Jump(); }
        */
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            collider.isTrigger = true;
            isFalling = true;
        }
        /*
        if(isJumping && (rigidBody.velocity.y == -0.1f))
        {
            Debug.Log(collider.isTrigger);
            Debug.Log(rigidBody.velocity.y);
            isJumping = false;
            isFalling = true;
        }
        if(transform.position.x < defaultPosition.x)
        {
            transform.Translate(returnVector * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        { anim.SetBool("jump", true); }
        if(Input.GetKey(KeyCode.DownArrow))
        { anim.SetBool("fall", true); }
        */
    }
    void FixedUpdate()
    {
        isGrounded = CheckGround();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        anim.SetBool("jump", false);
        anim.SetBool("fall", false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if(isJumping)
        {
            collider.isTrigger = true;
            isFalling = true;
        }
        */
        Debug.Log($"isFalling:{isFalling}, velocity:{GetComponent<Rigidbody>().velocity.y}");
        if(isFalling || (rigidBody.velocity.y < -0.1f))
        {
            collider.isTrigger = false;
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        /*
        if(isJumping && !isGrounded)
        {
            collider.isTrigger = false;
            isJumping = false;
        }
        */
        if(isFalling)
        {
            collider.isTrigger = false;
            isFalling = false;
        }
    }
    void Jump()
    {
        rigidBody.AddForce(jumpVector, ForceMode2D.Impulse);
        isJumping = true;
        collider.isTrigger = true;
    }
    //引用元：4dcsummer2023
    private bool CheckGround()
    {
        Vector2 positionLeft = (Vector2)transform.position - Vector2.left * 0.35f - Vector2.up;
        Vector2 positionRight = (Vector2)transform.position - Vector2.right * 0.5f - Vector2.up;
        Vector2 direction = Vector2.down;
        float distance = 0.3f;

        RaycastHit2D hitLeft = Physics2D.Raycast(positionLeft, direction, distance);
        Debug.DrawRay(positionLeft, direction * distance, Color.red);
        RaycastHit2D hitRight = Physics2D.Raycast(positionRight, direction, distance);
        Debug.DrawRay(positionRight, direction * distance, Color.red);
        return hitLeft.collider != null && hitRight.collider != null;
    }
}
