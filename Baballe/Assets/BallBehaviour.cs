using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {
    public int bounceNumber;
    protected Rigidbody rb;
    public bool isSticked;
    
    private void Start() {
        this.rb = this.GetComponent<Rigidbody>();
    }
    
    public void Stick() {
        this.isSticked = true;
        this.rb.useGravity = false;
        this.rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
