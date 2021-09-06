using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class PauseScreenManager : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Exit()
    {
        pauseScreen.SetActive(false);
        Application.Quit();
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(!pauseScreen.activeSelf);
        }
    }
}
