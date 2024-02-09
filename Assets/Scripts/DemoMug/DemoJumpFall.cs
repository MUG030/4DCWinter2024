using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoJumpFall : MonoBehaviour
{

    private float _Speed = 5.0f;
    [SerializeField] private float _JumpPower = 15.0f;
    private Rigidbody2D _rb;
   

    public LayerMask whatIsGround;
    private Transform groundCheckPoint;
    private Animator anim = null;
    private Transform transform;
    private Vector2 defaultPosition;
    [SerializeField]
    private float returnSpeed = 0.3f;
    private Vector2 returnVector;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        groundCheckPoint = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        returnVector = new Vector2(returnSpeed, 0);
        transform = gameObject.transform;
        defaultPosition = transform.position;
    }

    void Update()
    {
        //float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if ( inputY > 0 && _rb.velocity.y == 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpPower);
            anim.SetBool("jump", true);
        }
        else if( inputY < -0.5 && _rb.velocity.y == 0)
        {
            anim.SetBool("fall", true);
            Debug.Log("�����́�Jump");
            Collider2D[] hitFloors = Physics2D.OverlapCircleAll(groundCheckPoint.position, 2f, whatIsGround);
            foreach(Collider2D hitFloor in hitFloors)
            {
                PlatformManager platformManager = hitFloor.GetComponent<PlatformManager>();
                if ( platformManager != null )
                {
                    Debug.Log("�Ă΂ꂽ");
                    hitFloor.GetComponent<PlatformManager>().Through();
                }
                
            }
                //= Physics2D.OverlapCircleAll(groundCheckPoint.position, 2f, whatIsGround);
        }

        Vector2 vector2 = new Vector2(0, _rb.velocity.y);
        _rb.velocity = vector2;
        if(transform.position.x < defaultPosition.x)
        {
            transform.Translate(returnVector * Time.deltaTime);
        }

    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(_rb.velocity.y != 0)
        {
            return;
        }
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
    }
    void OnBecameInvisible()
    {
        if(groundCheckPoint.position.y < -5)
        {
            Debug.Log("GameOver_Falling");
            //落下死の処理
            GameManager.instance.FallDead();
        }
    }

}
