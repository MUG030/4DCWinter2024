using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private float knockBackForce = 5.0f;
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
      

        // 左方向へのノックバックを適用
        Vector2 knockBackDirection = new Vector2(-1, 2).normalized;
        rbody2.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);

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
    }
}
