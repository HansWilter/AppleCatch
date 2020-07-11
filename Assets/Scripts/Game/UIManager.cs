using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager = default;

    [SerializeField]
    private Text scoreText = default;
    [SerializeField]
    private Image[] lives = default;

    private Player player = default;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
        if (player == null)
        {
            Debug.LogError("Player is Null");
        }

        UpdateScore();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("Game Manager is NULL");
        }
    }

    
    public void UpdateScore()
    {
        scoreText.text = "" + player.GetScore();
    }

    public void UpdateLives(int currentLives)
    {
        if (currentLives == 2)
        {
            lives[2].gameObject.SetActive(false);
        }
        else if (currentLives == 1)
        {
            lives[1].gameObject.SetActive(false);
        }
        else
        {
            lives[0].gameObject.SetActive(false);
            float oldHighscore = PlayerPrefs.GetFloat("Highscore");
            if (player.GetScore() > oldHighscore)
            {
                PlayerPrefs.SetFloat("Highscore", player.GetScore());
            }
            gameManager.GameOver();
        }
    }
    
    public void Resume()
    {
        gameManager.ResumeGame();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }



}
