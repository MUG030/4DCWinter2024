using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuraGoldScore : MonoBehaviour
{
    private ScoreController scoreController;
    void Start()
    {
        scoreController = GameObject.Find("ScoreManager").GetComponent<ScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Golden Ikura Get!");
            scoreController.UpdateScoreView(300);
            GameManager.instance.AddIkuraGetCount();
            Destroy(gameObject);
        }
    }
}
