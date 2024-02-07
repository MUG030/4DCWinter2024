using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroy : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnBecameVisible()
    {
        Debug.Log("visible");
    }
}
