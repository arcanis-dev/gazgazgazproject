using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour {
    [SerializeField] private float sunMass = 1;
    [SerializeField] private float loseSpeed = 1;
    [SerializeField] private float eatingSpeed = 1;
    [SerializeField] private Color sunColor = Color.white;
    
    public IEnumerable EatGas() {
        float min = 0;
        while (min < 0) {
            this.sunMass -= Mathf.Lerp(min, 1, Time.deltaTime * this.eatingSpeed);
            min += Time.deltaTime;
            yield return null;
        }
    }

    private void Update() {
        this.LoseMass();
    }

    public void LoseMass() {
        this.sunMass -= loseSpeed * Time.unscaledDeltaTime;
    }

}
