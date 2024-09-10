using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Lobby");
    }

     public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

}
