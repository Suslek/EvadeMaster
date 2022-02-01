using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = GameManager.speed;

    void Update()
    {
        gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
