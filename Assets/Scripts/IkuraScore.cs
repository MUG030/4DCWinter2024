using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkuraScore : MonoBehaviour
{
    public ScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Ikura Get!");
            scoreController.UpdateScoreView(100);
            Destroy(gameObject);
        }
    }
}
