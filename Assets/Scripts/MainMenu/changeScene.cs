using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Mia Scene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlScheme");
    }

    public void ExitGame()
    {
        Debug.Log("lame");
        Application.Quit();
    }
}
