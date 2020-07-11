using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playGame, highscore, settings, quit;
    [SerializeField]
    private Text highscoreText = default;

    public void Play()
    {
        // load game scene
        SceneManager.LoadScene(1);
    }

    public void ViewHighscore()
    {
        highscoreText.text = "Your highscore: " + PlayerPrefs.GetFloat("Highscore");
        highscoreText.gameObject.SetActive(true);
    }

    public void Settings()
    {
        // settings scene
        StartCoroutine(wait());
        SceneManager.LoadScene(3);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
