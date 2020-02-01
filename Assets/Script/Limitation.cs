using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitation : MonoBehaviour
{
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;


    void Update()
    {
        if (transform.position.x < xmin )
        {
            transform.position = new Vector3(xmax-1, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xmax)
        {
            transform.position = new Vector3(xmin + 1, transform.position.y, transform.position.z);
        }

        if (transform.position.y < ymin)
        {
            transform.position = new Vector3(transform.position.x, ymax-1, transform.position.z);
        }

        if (transform.position.y > ymax)
        {
            transform.position = new Vector3(transform.position.x, ymin + 1, transform.position.z);
        }

    }
}
