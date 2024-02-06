using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene2 : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
