using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlatformEffector2D platformEffector2D;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        platformEffector2D = GetComponent<PlatformEffector2D>();
    }

    public void Through()
    {
        platformEffector2D.surfaceArc = 0;
        Invoke("Reset", 0.6f);
    }

    public void Reset()
    {
        platformEffector2D.surfaceArc = 180;
    }
}
