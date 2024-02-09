using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene2 : MonoBehaviour
{
    public void change_button()
    {
        GameManager.instance.AddClearCount();
        if (GameManager.instance.score == 0)
        {
            GameManager.instance.ikuraZero = true;
        }
        SceneManager.LoadScene("ClearScene");
    }
}
