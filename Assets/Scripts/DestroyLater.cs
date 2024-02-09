using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", 10.0f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
