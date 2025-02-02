using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "ControlScheme" && Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Rebrand");
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
