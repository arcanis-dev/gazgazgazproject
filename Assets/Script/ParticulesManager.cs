﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesManager : MonoBehaviour
{
    public int bouleGazNb;
    public GameObject particule;
    public bool echanging;

    void Start()
    {
        for (int i = 0; i < bouleGazNb; i++)
        {
            GameObject bouleGaz = Instantiate(particule,new Vector3(transform.position.x + Random.Range(-0.75f,0.76f), transform.position.y + Random.Range(-0.5f, 0.6f),transform.position.z),particule.transform.rotation);
            bouleGaz.transform.parent = transform;
        }

    }


}
