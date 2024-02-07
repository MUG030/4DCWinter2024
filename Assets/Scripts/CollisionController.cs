using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    private int lifecount = 3;

    public GameObject firstBar;
    public GameObject secondBar;
    public GameObject thirdBar;
    public GameObject deathBar;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DenchiScene")
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        lifecount = 3;
        firstBar.SetActive(true);
        secondBar.SetActive(false);
        thirdBar.SetActive(false);
        deathBar.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "trap")
        {
            lifecount--;
            if (lifecount == 2)
            {
                firstBar.SetActive(false);
                secondBar.SetActive(true);
            }
            else if (lifecount == 1)
            {
                secondBar.SetActive(false);
                thirdBar.SetActive(true);
            }
            else if (lifecount == 0)
            {
                thirdBar.SetActive(false);
                deathBar.SetActive(true);
            }
            
        }
    }
}
