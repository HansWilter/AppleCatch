using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float score = 0f;

    private int lives = 3;

    private UIManager uiManager;
    private GameManager gameManager;

    private AudioSource audioSourceCollect;

    // Start is called before the first frame update
    void Start()
    {
        // starting position for player
        transform.position = new Vector3(0f, -4.2f, 0);

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (uiManager == null || gameManager == null)
            Debug.LogError("UIManager or GameManager is null");

        
        audioSourceCollect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver())
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        float xMin = -6f;
        float xMax = 6f;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y);
    }

    public void Collect(float points)
    {
        // TODO: play an audio cue
        audioSourceCollect.Play();
        score += points;
        uiManager.UpdateScore();
    }

    public float GetScore()
    {
        return score;
    }

    public void Damage()
    {
        --lives;
        uiManager.UpdateLives(lives);
    }

    public int GetLives()
    {
        return lives;
    }

    public void AddToSpeed(float speedToAdd)
    {
        speed += speedToAdd;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
