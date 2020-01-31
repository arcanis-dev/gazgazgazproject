using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesManager : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public bool move;
    public GameObject target;
    void Update()
    {
        if (move == true)
        {
           transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "zoneEchange")
        {
            Debug.Log("ok");
            target = col.gameObject;
            move = true;
        }
    }
}
