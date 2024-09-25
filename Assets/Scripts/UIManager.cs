using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
