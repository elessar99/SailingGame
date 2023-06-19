using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Start game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        // Exit game
        Application.Quit();
    }
}
