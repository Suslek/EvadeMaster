using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour
{
    private float Bound = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.z) > Bound || Mathf.Abs(transform.position.x) > Bound)
        {
            Destroy(gameObject);
        }
    }
}
