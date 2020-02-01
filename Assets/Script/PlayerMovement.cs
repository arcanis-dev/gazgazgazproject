using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
[Header("Movement Parameters")]

public float MoveSpeed = 1;

[Range(0,0.30f)]
public float Acceleration;
[Range(0,0.30f)]
public float Decceleration;
float x_inertia = 0;
float y_inertia = 0;
float AxX = 0;
float AxY = 0;

//code


    void FixedUpdate()
    {
        AxX = Input.GetAxis("Horizontal");
        AxY = Input.GetAxis("Vertical");

Debug.Log(AxX);
        MoveObject();
    }

    void MoveObject()
    {
        if (AxX > 0f)
        x_inertia = Mathf.Lerp(x_inertia, 1f, Acceleration*Time.deltaTime*60);
        if (AxX < 0f)
        x_inertia = Mathf.Lerp(x_inertia, -1f, Acceleration*Time.deltaTime*60);
        if (Mathf.Abs(AxX) < 0.2f)
         x_inertia = Mathf.Lerp(x_inertia, 0f, Decceleration *Time.deltaTime*60);
        
        if (AxY > 0f)
        y_inertia = Mathf.Lerp(y_inertia, 1f, Acceleration*Time.deltaTime*60);
        if (AxY < 0f)
        y_inertia = Mathf.Lerp(y_inertia, -1f, Acceleration*Time.deltaTime*60);
        if (Mathf.Abs(AxX) < 0.2f)
        y_inertia = Mathf.Lerp(y_inertia, 0f, Decceleration *Time.deltaTime*60);

        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed* x_inertia,MoveSpeed * y_inertia);

    }
}
