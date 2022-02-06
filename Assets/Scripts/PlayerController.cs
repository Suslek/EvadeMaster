using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float border = 14.0f;

    private bool isPowerUp;
    private bool gameActive;

    public static UnityEvent OnGameEnd = new UnityEvent();

    private void Start()
    {
        UIController.OnGameStart.AddListener(gameStart);
    }

    void Update()
    {
        if (gameActive) 
        {
            ControllInput();
            BordersDetection();
        }
    }

    void gameStart()
    {
        gameActive = true;
    }

    void ControllInput()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // ”правление через transform.Translate
        gameObject.transform.Translate(hInput * speed * Time.deltaTime, 0, 0);
        gameObject.transform.Translate(0, 0, vInput * speed * Time.deltaTime);
    }

    void BordersDetection()
    {
        if (transform.position.x > border)
        {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -border)
        {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z);
        }

        if (transform.position.z > border)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, border);
        }

        if (transform.position.z < -border)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -border);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isPowerUp)
        {
            Destroy(gameObject);
            OnGameEnd.Invoke();
            gameActive = false;
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            isPowerUp = true;
            StopCoroutine(PowerUpCoolDown());
            StartCoroutine(PowerUpCoolDown());
//            powerUpIndicator.SetActive(true);
        }
    }

    IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(3);
//        powerUpIndicator.SetActive(false);
        isPowerUp = false;
    }

}
