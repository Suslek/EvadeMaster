using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = GameManager.speed;

    void Update()
    {
        gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
