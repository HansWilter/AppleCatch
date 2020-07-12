using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject applePrefab = default;
    [SerializeField]
    private Player player = default;

    // apple spawning logic variables
    private float appleSpawnInterval = 4;
    private float appleWaveIncrease = 0;

    // game over bool - stop when game is over
    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAppleRoutine());
    }

    IEnumerator SpawnAppleRoutine()
    {
        yield return new WaitForSeconds(3);
        while (stopSpawning == false)
        {
            // instantiate a new apple object at a random pos
            Vector3 spawnPos = new Vector3(Random.Range(-7, 7), 8, 0);
            GameObject newApple = Instantiate(applePrefab, spawnPos, Quaternion.identity);

            if (appleSpawnInterval > 2)
            {
                appleSpawnInterval -= 0.1f;
            }
            else if (appleSpawnInterval >= 1)
            {
                appleSpawnInterval -= 0.05f; // increase spawn rate slower
            }
            else if (appleSpawnInterval < 1)
            {
                if (appleWaveIncrease == 10)
                {
                    if (appleSpawnInterval > .5f)
                    {
                        appleSpawnInterval -= .1f;
                        player.AddToSpeed(1.5f);
                    }
                    appleWaveIncrease = 0;
                }
                else
                {
                    appleWaveIncrease++;
                }
            }
            yield return new WaitForSeconds(appleSpawnInterval);

        }
    }
}
