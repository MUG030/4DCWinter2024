using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 5.0f;
    private Vector2 scrollVector;
    void Start()
    {
        scrollVector = new Vector2(-scrollSpeed, 0);
    }
    void Update()
    {
        transform.Translate(scrollVector * Time.deltaTime);
        
        if(this.transform.childCount == 0)
        { Destroy(this); }
    }
}
