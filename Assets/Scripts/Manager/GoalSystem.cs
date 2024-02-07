using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSystem : MonoBehaviour
{
    public DemoSceneChange demoSceneChange;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Goal");
            // demoSceneChange.ChangeScene();
        }
    }
}
