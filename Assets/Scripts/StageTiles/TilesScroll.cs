using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 5.0f;
    private Vector2 scrollVector;
    private Transform parent;
    private TileFullVisible[] childrenVisible;
    public bool isAllChildVisible = false;
    void Start()
    {
        scrollVector = new Vector2(-scrollSpeed, 0);
        
        parent = gameObject.transform;
        childrenVisible = new TileFullVisible[parent.childCount];
        for(int i = 0; i < childrenVisible.Length; ++i)
        { childrenVisible[i] = parent.GetChild(i).GetComponent<TileFullVisible>(); }
    }
    void Update()
    {
        transform.Translate(scrollVector * Time.deltaTime);
        
        if(parent.childCount == 0)
        { Destroy(this); }

        if(!isAllChildVisible)
        {
            for(int i = 0; i < childrenVisible.Length; i++)
            {
                if(!childrenVisible[i].isFullVisible)
                    return;
            }
            isAllChildVisible = true;
        }
    }
}
