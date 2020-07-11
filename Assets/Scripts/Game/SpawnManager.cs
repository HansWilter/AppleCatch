using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject applePrefab = default;

    // apple spawning logic variables
    private int appleSpawnInterval = 4;
    private float appleWaveIncrease = 20;
    private float appleIncreaseCountdown = 0;

    // game over bool - stop when game is over
    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAppleRoutine());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnAppleRoutine()
    {
        yield return new WaitForSeconds(3);
        while (stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-7, 7), 8, 0);
            GameObject newApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);

            appleIncreaseCountdown = Time.timeSinceLevelLoad;

            if (appleIncreaseCountdown >= appleWaveIncrease)
            {
                appleIncreaseCountdown = 0;
                appleWaveIncrease += 20;
                if (appleSpawnInterval > 1)
                {
                    Debug.Log("New Spawn Rate - " + appleSpawnInterval);
                    appleSpawnInterval -= 1;
                }
            }
            yield return new WaitForSeconds(appleSpawnInterval);

        }
    }
}
