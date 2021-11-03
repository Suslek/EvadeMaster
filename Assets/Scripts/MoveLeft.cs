using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private GameManager gameManager;
    private float speed;
    //    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = gameManager.speed;
        //        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
//        objectRb.AddForce(Vector3.left * speed);
    }
}
