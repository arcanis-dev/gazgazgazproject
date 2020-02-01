using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSurface : MonoBehaviour {
    public float scrollSpeed = 5f;
    private Vector2 startPos;

    private void Start() {
        this.startPos = transform.position;
    }

    private void Update() {
        float newPos = Mathf.Repeat(Time.time * this.scrollSpeed, this.GetComponent<SpriteRenderer>().bounds.size.x);
        transform.position = this.startPos + Vector2.left * newPos;
    }
}
