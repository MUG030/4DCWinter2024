using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // 同じタイプのオブジェクトを検索
        DontDestroy[] objs = GameObject.FindObjectsOfType<DontDestroy>();

        // 同じタイプのオブジェクトが1つ以上存在する場合、現在のオブジェクトを破棄
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
