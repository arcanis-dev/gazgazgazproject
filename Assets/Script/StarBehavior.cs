﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {
    [SerializeField] private float starMass = 1;
    [SerializeField] private float maxStarMass = 1f;
    [SerializeField] private float loseSpeed = 1;
    [SerializeField] private float eatingSpeed = 1;
    [SerializeField] private float scaleFactor;

    [SerializeField] private Color[] colors = new Color[3];
    public SpriteRenderer sr;

    private void Start() {
        sr = this.GetComponent<SpriteRenderer>();
    }

    public IEnumerator EatGas() {
        float min = 0;
        while (min < 1) {
            if (starMass < maxStarMass)
            {
                starMass += Time.deltaTime;
            }
            min += Time.deltaTime;
            yield return null;
        }
    }

    private void Update() {
        ChangeScale();
        this.LoseMass();
    }

    private void ChangeScale(){

        transform.localScale = Vector3.one * Mathf.Clamp(starMass / scaleFactor, 0, 1) ;
    }

    public void LoseMass() {
        if (this.starMass > 0)
        {
            this.starMass -= loseSpeed * Time.unscaledDeltaTime;
        }
        else
        {
            Debug.Log("boom");
        }

    }

    public void UpdateColor(Color col) {
        sr.color = col;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "particle")
        {
            Destroy(col.gameObject);
            Debug.Log("ok");
            if(starMass < maxStarMass)
            {
                StartCoroutine(EatGas());
            }
            
        }
    }

}