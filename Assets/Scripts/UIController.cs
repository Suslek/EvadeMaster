using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public static UnityEvent OnGameStart = new UnityEvent();

    public GameObject gameOverScreen;
    public GameObject titleScreen;

    public TextMeshProUGUI scoreText;

    private float score;

    private bool gameActive;

    private void Start()
    {
        PlayerController.OnGameEnd.AddListener(GameOver);
    }

    public void StartGame()
    {
        OnGameStart.Invoke();
        titleScreen.SetActive(false);
        score = 0;
        StartCoroutine(ScoreUpdate());
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ScoreUpdate()
    {
        while (gameActive)
        {
            scoreText.text = "Score: " + score;
            score++;
            yield return new WaitForSeconds(1);
        }
    }
}
