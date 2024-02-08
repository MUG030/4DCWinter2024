using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoJumpFall : MonoBehaviour
{

    private float _Speed = 5.0f;
    [SerializeField] private float _JumpPower = 20.0f;
    private Rigidbody2D _rb;
   

    public LayerMask whatIsGround;
    private Transform groundCheckPoint;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        groundCheckPoint = GetComponent<Transform>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if ( inputY > 0 && _rb.velocity.y == 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpPower);
        }
        else if( inputY < -0.5 && _rb.velocity.y == 0)
        {
            Debug.Log("‰º“ü—Í•Jump");
            Collider2D[] hitFloors = Physics2D.OverlapCircleAll(groundCheckPoint.position, 2f, whatIsGround);
            foreach(Collider2D hitFloor in hitFloors)
            {
                PlatformManager platformManager = hitFloor.GetComponent<PlatformManager>();
                if ( platformManager != null )
                {
                    Debug.Log("ŒÄ‚Î‚ê‚½");
                    hitFloor.GetComponent<PlatformManager>().Through();
                }
                
            }
                //= Physics2D.OverlapCircleAll(groundCheckPoint.position, 2f, whatIsGround);
        }

        Vector2 vector2 = new Vector2(inputX * _Speed, _rb.velocity.y);
        _rb.velocity = vector2;
    }
    
}
