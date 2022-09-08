using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Update()
    {
    }
    public void Restart()
    {
        SceneManager.LoadScene("Video", LoadSceneMode.Single);
    }

    public void End()
    {
        Application.Quit();
    }
}
