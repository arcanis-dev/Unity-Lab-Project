using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    private Transform hand;
    public GameObject baballe;
    private Rigidbody ballRigidbody;
    private Collider ballCollider;

    public float throwForceMin = 1f;
    public float throwForceMax = 5f;
    public float upForce = 1.2f;
    public float throwAmount = 1.5f;
    
    public bool hasBall = true;

    private void Awake() {
        this.hand = transform.Find("Hand");
        this.ballRigidbody = this.baballe.GetComponent<Rigidbody>();
        this.ballRigidbody.position = this.hand.position;
        this.ballRigidbody.useGravity = false;
        this.ballCollider = baballe.GetComponent<Collider>();
        EnableBall(false);
    }
    
    private void Update() {
        if (Input.GetButtonDown("Fire1")){
            if (hasBall) {
                //Start throwing
                this.ThrowBall();
                StartCoroutine(this.ThrowBall());
            }
            else if(!this.hasBall){
                this.RecallBall();
            }
        }
        
        Debug.Log("iskine" + this.ballRigidbody.isKinematic);
        Debug.Log("usegrav" + this.ballRigidbody.useGravity);
        
    }

    private IEnumerator ThrowBall() {
        float throwForce = this.throwForceMin;
        Debug.Log("throw");

        while (Input.GetButton("Fire1")) {
            throwForce += throwAmount;
            yield return null;
        }

        if (Input.GetButtonUp("Fire1")) {
            throwForce = Mathf.Clamp(throwForce, this.throwForceMin, this.throwForceMax);
            Debug.Log(throwForce);
            this.hasBall = false;
            EnableBall(true);
            this.ballRigidbody.AddForce(this.hand.forward * throwForce + this.hand.up * this.upForce, ForceMode.Impulse);
        }
        
    }

    private void FixedUpdate() {
        if (this.hasBall) {
            this.ballRigidbody.position = this.hand.position;
            this.ballRigidbody.rotation = this.hand.rotation;
        }
    }

    public void RecallBall() {
        Debug.Log("recall");
        //tp balle + "désactive" la balle
        
        this.hasBall = true;
        this.EnableBall(false);
        this.ballRigidbody.position = this.hand.position;
        
    }

    public void EnableBall(bool isTrue) {
        this.ballRigidbody.isKinematic = !isTrue;
        this.ballRigidbody.useGravity = isTrue;
        this.ballCollider.enabled = isTrue;
    }
}
