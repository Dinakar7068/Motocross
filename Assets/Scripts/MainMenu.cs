using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void BikeSelectScene()
    {
        SceneManager.LoadScene("BikeSelection");
    }

    public void LevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game..."); 
        Application.Quit(); 
    }
}
