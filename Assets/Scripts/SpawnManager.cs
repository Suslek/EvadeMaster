using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;

    public static float speed;
    public static float border = 17f;

    private float delayTime = 5;
    private int waveCount;
    private int counter = 0;


    public bool gameActive;

    private int _waveCount;

    private void Start()
    {
        UIController.OnGameStart.AddListener(StartGame);
        PlayerController.OnGameEnd.AddListener(EndGame);
    }

    private void StartGame()
    {
        gameActive = true;
        waveCount = 0;
        _waveCount = waveCount + 5;
        delayTime = 5;
        speed = 5f;
        StartCoroutine(SpawnDelay());
    }

    private void EndGame()
    {
        gameActive = false;
    }

    IEnumerator SpawnDelay()
    {
        while (gameActive)
        {
            for (int i = 0; i < _waveCount; i++)
            {
                SpawnEnemy();
            }

            if (counter % 2 == 0 && counter < 15)
            {
                delayTime *= 0.95f;
            }
            else if (speed < 20)
            {
                speed *= 1.1f;
            }
            else if (speed >= 20 && delayTime >= 1.5f)
            {
                delayTime *= 0.9f;
            }

            if (waveCount < 15)
            {
                waveCount++;
                _waveCount++;
            }

            counter++;

            yield return new WaitForSeconds(delayTime);
        }
    }

    float RandomNumber()
    {
        float Position;
        Position = Random.Range(-14f, 14f);

        return Position;
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0,4);

        Vector3 spawnPos;

        if (randomIndex == 0)
        {
            spawnPos = new Vector3(RandomNumber(), 0.5f, border);
            Instantiate(enemy, spawnPos, enemy.gameObject.transform.rotation);
        }
        else if (randomIndex == 1)
        {
            spawnPos = new Vector3(border, 0.5f, RandomNumber());
            Instantiate(enemy, spawnPos, enemy.gameObject.transform.rotation);
        }
        else if (randomIndex == 2)
        {
            spawnPos = new Vector3(-border, 0.5f, RandomNumber());
            Instantiate(enemy, spawnPos, enemy.gameObject.transform.rotation);
        }
        else if (randomIndex == 3)
        {
            spawnPos = new Vector3(RandomNumber(), 0.5f, -border);
            Instantiate(enemy, spawnPos, enemy.gameObject.transform.rotation);
        }
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3(RandomNumber(), 0.5f, RandomNumber());
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
