using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {
    [SerializeField] private float starMass = 1;
    [SerializeField] private float loseSpeed = 1;
    [SerializeField] private float eatingSpeed = 1;

    [SerializeField] private Color[] colors = new Color[3];
    private SpriteRenderer sr;

    private void Start() {
        sr = this.GetComponent<SpriteRenderer>();
    }

    public IEnumerable EatGas() {
        float min = 0;
        while (min < 0) {
            this.starMass -= Mathf.Lerp(min, 1, Time.deltaTime * this.eatingSpeed);
            min += Time.deltaTime;
            yield return null;
        }
    }

    private void Update() {
        this.LoseMass();
    }

    public void LoseMass() {
        this.starMass -= loseSpeed * Time.unscaledDeltaTime;
    }

    public void UpdateColor(Color col) {
        sr.color = col;
        
    }

}
