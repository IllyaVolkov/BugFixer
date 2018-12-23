using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvokeSceneLoading : MonoBehaviour
{
    public int gameTime;
    public int sceneIndex;

    void Start()
    {
        Invoke("LoadNextScene", gameTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
