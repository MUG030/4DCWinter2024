using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSystem : MonoBehaviour
{
    public Changescene2 changescene2;
    void Start()
    {
        changescene2 = GameObject.Find("SceneManager").GetComponent<Changescene2>();
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
        {
            // Debug.Log("Goal");
            changescene2.change_button();
        }
    }
}
