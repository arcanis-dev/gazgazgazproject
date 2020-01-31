using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaz : MonoBehaviour
{
    public int bouleGazNb;
    public GameObject g;
    public bool echanging;

    void Start()
    {
        for (int i = 0; i < bouleGazNb; i++)
        {
            GameObject bouleGaz = Instantiate(g,new Vector3(transform.position.x + Random.Range(-2,2), transform.position.y + Random.Range(-2, 2),transform.position.z),g.transform.rotation);
            bouleGaz.transform.parent = transform;
        }

    }


}
