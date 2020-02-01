using System.Collections;
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
            GameObject bouleGaz = Instantiate(particule,new Vector3(transform.position.x + Random.Range(-10.0f,10.0f), transform.position.y + Random.Range(-4.0f, 4.0f),transform.position.z),particule.transform.rotation);
            bouleGaz.GetComponent<Particule>().noyau = transform.gameObject;
            bouleGaz.transform.parent = transform;
        }

    }

    private void Update()
    {
        if (transform.childCount < 2)
        {
            Debug.Log("mort");
        }
    }


}
