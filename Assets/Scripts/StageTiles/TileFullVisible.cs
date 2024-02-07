using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFullVisible : MonoBehaviour
{
    public bool isFullVisible = false;
    private Transform transform;
    private float _transform_rightedge;
    private SpriteRenderer spriteRenderer;
    private static float camRightSide_X = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(camRightSide_X == 0f)
        {
            camRightSide_X = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
            Debug.Log(camRightSide_X);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFullVisible)
        {
            _transform_rightedge = gameObject.transform.position.x
                                + (spriteRenderer.size.x / 2);
            if(_transform_rightedge < camRightSide_X)
            {
                isFullVisible = true;
                Debug.Log($"{transform.position.y}:FullVisible");
            }
        }
    }
}
