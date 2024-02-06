using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescene3 : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
