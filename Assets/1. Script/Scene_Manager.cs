using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("pruebas", LoadSceneMode.Single);
    }

    public void End()
    {
        Application.Quit();
    }
}
