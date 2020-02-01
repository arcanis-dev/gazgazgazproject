using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour {
    [SerializeField] private float starMass = 1;
    [SerializeField] private float maxStarMass = 1f;
    [SerializeField] private float loseSpeed = 1;
    [SerializeField] private float eatingSpeed = 1;
    [SerializeField] private float scaleFactor;
    
    [SerializeField] private Gradient sunGradient;
    
    public SpriteRenderer starRenderer;
    public SpriteRenderer FieldRenderer;

    [SerializeField] private Color[] colors = new Color[3];
    public SpriteRenderer sr;
    public GameObject field;
    public GameObject surface;
    public GameObject star;
    public GameObject blackhole;
    bool isblackhole;
    bool blackholetransition;
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
        this.ChangeColor();
        this.LoseMass();
    }

    private void ChangeScale(){
        transform.localScale = Vector3.one * Mathf.Clamp(starMass / scaleFactor, 0, 1) ;
    }

    public void ChangeColor() {
        var alpha = this.FieldRenderer.color.a;
        this.FieldRenderer.color = this.sunGradient.Evaluate(this.starMass / this.maxStarMass);
        this.FieldRenderer.color = new Color(this.FieldRenderer.color.r, this.FieldRenderer.color.b, this.FieldRenderer.color.b, alpha);
        alpha = this.starRenderer.color.a;
        this.starRenderer.color = this.sunGradient.Evaluate(this.starMass / this.maxStarMass);
        this.starRenderer.color = new Color(this.starRenderer.color.r, this.starRenderer.color.b, this.starRenderer.color.b, alpha);
    }

    public void LoseMass() {
        if (this.starMass > 2 && blackholetransition == false)
        {
            this.starMass -= loseSpeed * Time.unscaledDeltaTime;
        }
        else
        {
            if (blackholetransition == false)
            {
                surface.GetComponent<Renderer>().enabled = false;
                field.GetComponent<Renderer>().enabled = false;
                star.GetComponent<Renderer>().enabled = false;
                blackhole.GetComponent<Renderer>().enabled = true;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Formationtrounoir");
                blackholetransition = true;

            }
            else
            {
                this.starMass = 10.0f;
                blackhole.GetComponent<Animator>().SetBool("bhole",true);
            }
        }

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
