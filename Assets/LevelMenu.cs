using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void OpenSecondLevel()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void OpenThirdLevel()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
}
