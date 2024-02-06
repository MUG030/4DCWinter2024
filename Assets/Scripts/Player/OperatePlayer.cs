using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatePlayer : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 0.5f;
    private Vector2 jumpVector;
    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        jumpVector = new Vector2(0f, jumpPower);
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) && isGrounded)
        { Jump(); }
    }
    void FixedUpdate()
    {
        isGrounded = CheckGround();
    }
    void OnBecameInvisible()
    {
        //落下時の処理を書く
    }
    void Jump()
    {
        rigidBody.AddForce(jumpVector, ForceMode2D.Impulse);
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
        return hitLeft.collider != null || hitRight.collider != null;
    }

}
