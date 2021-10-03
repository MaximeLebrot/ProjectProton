using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public void Play()
    {
        
        SceneManager.LoadScene(1);
        GameController.Health = 6;
    }


    
         

public void Paused()
    {

        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    public void MainMenu()
    {
       
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }


    
}
