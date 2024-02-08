using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool isTrapAttck;
    private float knockBackDistance = -2.0f;
    private float knockBackTime = 0.4f;

    private Rigidbody2D rbody2;
    private SpriteRenderer spriteRenderer;
  


    // Start is called before the first frame update
    void Start()
    {
        rbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    public void KnockBackPlayer()
    {
        Vector3 knockDistance = new Vector3(knockBackDistance, 0f, 0f);
        gameObject.transform.Translate(knockDistance);
        // 左方向へのノックバックを適用
       // Vector2 force = new Vector2(-6, 8);
        //rbody2.AddForce(force, ForceMode2D.Impulse);

        // ノックバックの持続時間後に力をリセット
        Invoke("ResetVelocity", knockBackTime);

        // 点滅を開始
        StartCoroutine(KnockBackFlash());
    }

    private void ResetVelocity()
    {
        rbody2.velocity = Vector2.zero;
    }

    private IEnumerator KnockBackFlash()
    {
        float endTime = Time.time + knockBackTime;
        float flashInterval = 0.1f;

        while (Time.time < endTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
        }

        spriteRenderer.enabled = true;
        isTrapAttck = false;
    }
}
