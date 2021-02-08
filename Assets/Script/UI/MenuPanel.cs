using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void CancelButton()
    {
        //SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    } 
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
