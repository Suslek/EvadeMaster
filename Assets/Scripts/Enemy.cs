using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 direction;

    private float speed = SpawnManager.enemySpeed;
    private float border = SpawnManager.border;

    private bool gameActive = true;

    private void Awake()
    {
        PlayerController.OnGameEnd.AddListener(GameEnd);

        if (transform.position.x == border)
        {
            direction = Vector3.left;
        }
        else if (transform.position.x == -border)
        {
            direction = Vector3.right;
        }
        else if (transform.position.z == border)
        {
            direction = Vector3.back;
        }
        else if(transform.position.z == -border)
        {
            direction = Vector3.forward;
        }
    }

    private void Update()
    {
        if (gameActive)
        {
            transform.position += direction * speed * Time.deltaTime;
        }  
    }

    private void GameEnd()
    {
        gameActive = false;
    }
}
