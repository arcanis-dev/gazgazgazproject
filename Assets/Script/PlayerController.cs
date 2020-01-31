using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float forceScale = 5f;
    private Rigidbody2D rb;
    private Vector2 movementForce;

    private float horizontalInput;
    private float verticalInput;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.verticalInput = Input.GetAxis("Vertical");
        this.movementForce = new Vector2(this.horizontalInput, this.verticalInput).normalized;
    }

    private void FixedUpdate() {
        this.rb.AddForce(movementForce * this.forceScale, ForceMode2D.Force);
    }
}
