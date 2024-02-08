using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 5.0f;
    private Vector2 scrollVector;
    private Transform parent;
    void Start()
    {
        scrollVector = new Vector2(-scrollSpeed, 0);
        
        parent = gameObject.transform;
    }
    void Update()
    {
        transform.Translate(scrollVector * Time.deltaTime);
        
        //if(parent.childCount == 0)
        //{ Destroy(gameObject); }
    }
}
