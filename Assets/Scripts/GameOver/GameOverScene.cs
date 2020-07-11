using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public void Restart()
    {
        // load game scene
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        // load Main Menu Scene
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        // Quit the application
        Application.Quit();
    }
}
