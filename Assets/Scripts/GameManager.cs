using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public float speed;
    public GameObject gameOverScreen;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;

    private float delayTime = 5;
    private int waveCount;
    private int counter = 0;
    private float border = 17f;
    private float score;

    public bool isGameActive;

    public void StartGame()
    {
        score = 0;
        titleScreen.SetActive(false);
        isGameActive = true;
        speed = 5f;
        waveCount = 5;
        delayTime = 5;
        StartCoroutine(SpawnDelay());
        StartCoroutine(ScoreUpdate());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ScoreUpdate()
    {
        while (isGameActive)
        {
            scoreText.text = "Score: " + score;
            score++;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnDelay()
    {
        while (isGameActive)
        {
            for (int i = 0; i < waveCount; i++)
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
            }

            counter++;
            if (counter % 3 == 0)
            {
                SpawnPowerUp();
            }

            yield return new WaitForSeconds(delayTime);
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    float RandomNumber()
    {
        float Position;
        Position = Random.Range(-14f, 14f);

        return Position;
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPos = new Vector3 (RandomNumber(), 0.5f, RandomNumber());
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos;

        if (randomIndex == 0)
        {
            spawnPos = new Vector3(RandomNumber(), 0.5f, border);
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
        else if (randomIndex == 1)
        {
            spawnPos = new Vector3(border, 0.5f, RandomNumber());
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
        else if (randomIndex == 2)
        {
            spawnPos = new Vector3(-border, 0.5f, RandomNumber());
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
        else if (randomIndex == 3)
        {
            spawnPos = new Vector3(RandomNumber(), 0.5f, -border);
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }
}
