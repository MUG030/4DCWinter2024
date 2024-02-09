using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChannel : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ((scene.name == "ClearScene" || scene.name == "ClearDemo") && IsDuplicateSceneActive(scene.name))
        {
            Invoke("ActivateObject", 10.0f);
        }
    }

    private void ActivateObject()
    {
        gameObject.SetActive(true);
    }

    private bool IsDuplicateSceneActive(string sceneName)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Scene duplicateScene = SceneManager.GetSceneByName(sceneName);

        return activeScene == duplicateScene;
    }
}
