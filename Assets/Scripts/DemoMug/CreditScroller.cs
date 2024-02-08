using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScroller : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // スクロール速度
    public float scrollThresholdY = 10.0f; // スクロールの閾値Y座標
    private Vector3 initialPosition; // 初期位置

    void Start()
    {
        initialPosition = transform.position; // 初期位置を保存
    }

    void Update()
    {
        // Y座標をスクロール
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // 特定のY座標までスクロールしたら初期位置に戻す
        if (transform.position.y >= scrollThresholdY)
        {
            ResetPosition();
        }
    }

    // 初期位置に戻す
    void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
