using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    public float speed;
    public float speedrota;
    public GameObject noyau;
    public GameObject target;
    bool move;
    bool catchp;
    bool iscatch;
    private void Start()
    {
        
        float x = transform.position.x;
        float y = transform.position.y;
        StartCoroutine(RndMove());
    }

    void Update()
    {
       
        if (noyau == null)
        {
            noyau = gameObject;
        }

        if (move == true)
        {
           transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
        }
        else
        {
            transform.RotateAround(noyau.transform.position, Vector3.forward, Time.deltaTime * speedrota);
            
        }

        if (move == false && catchp == true && iscatch == false)
        {
            if (Vector3.Distance(transform.position,target.transform.position) >= 0.1)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            else
            {
                iscatch = true;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "zoneEchange")
        {
            transform.parent = null;
            target = col.gameObject;
            move = true;
        }

        if (col.gameObject.tag == "catch")
        {
            transform.parent = col.transform; 
            target = col.gameObject;
            catchp = true;
        }

        
    }

    IEnumerator RndMove()
    {
        yield return new WaitForSeconds(0.25f);
        if (move == false)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y + Random.Range(-0.1f, 0.1f), transform.position.z);
        }

        StartCoroutine(RndMove());

    }
}
