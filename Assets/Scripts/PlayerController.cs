using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float border = 14.0f;

    private GameManager gameManager;
    private bool isPowerUp;
//    [SerializeField] private GameObject powerUpIndicator;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        ControllInput();

        BordersDetection();
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
            gameManager.isGameActive = false;
            Destroy(gameObject);
            gameManager.GameOver();
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
