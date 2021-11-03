using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour
{
    private float Bound = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z < -Bound || transform.position.z > Bound || transform.position.x < -Bound || transform.position.x > Bound)
        {
            Destroy(gameObject);
        }
    }
}
