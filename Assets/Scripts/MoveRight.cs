using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = GameManager.speed;

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
