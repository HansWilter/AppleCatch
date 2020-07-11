using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuPanel = default, fadeImage = default;
    private Animator pauseAnimator, fadeAnimator = default;

    bool gamePaused = false;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseAnimator = pauseMenuPanel.GetComponent<Animator>();
        if (pauseAnimator == null)
        {
            Debug.LogError("Pause animator is null");
        }
        pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;

        fadeAnimator = fadeImage.GetComponent<Animator>();
        if (fadeAnimator == null)
        {
            Debug.LogError("Fade animation is null");
        }
        fadeAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == false)
            {
                gamePaused = true;
                FadeGame();
                pauseAnimator.SetTrigger("pause");
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void FadeGame()
    {
        fadeAnimator.SetBool("isPaused", true);
    }

    private void unFadeGame()
    {
        fadeAnimator.SetBool("isPaused", false);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        unFadeGame();
        pauseAnimator.SetTrigger("resume");
    }


    IEnumerator GameOverSequence()
    {
        gameOver = true;
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(2);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverSequence());
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
