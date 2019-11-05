using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class BallManager : MonoBehaviour {
    private Transform spawnPoint;
    public GameObject baballe;
    private Rigidbody ballRigidbody;

    public float throwForce = 1f;
    
    public bool hasBall;

    private void Awake() {
        this.spawnPoint = this.transform.GetChild(1);
        this.ballRigidbody = this.baballe.GetComponent<Rigidbody>();
    }
    
    private void Update() {
        if (Input.GetButton("Fire1")) {
            if (hasBall) {
                this.ThrowBall();
            }
        }
        
    }

    public void ThrowBall() {
        this.ballRigidbody.AddForce(transform.forward* this.throwForce, ForceMode.Impulse);
    }
}
