using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Restart()
    {
        SceneManager.LoadScene("Video", LoadSceneMode.Single);
    }

    public void Begin()
    {
        SceneManager.LoadScene("Inicio", LoadSceneMode.Single);
    }

    public void End()
    {
        Application.Quit();
    }
}
