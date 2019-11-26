using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;

public class StickyBallBehaviour : BallBehaviour
{
    public int maxBounceNumber;
    private float timerRebounce = 0;
    [SerializeField] private float timerRebounceMax = 0.3f;


    private void Update() {
        timerRebounce += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        if (!this.isSticked) {
            StartCoroutine(AddTimerRebound());
            if (timerRebounce > this.timerRebounceMax) {
                timerRebounce = 0;
                this.bounceNumber += 1;
            }
            
            Debug.Log("BOUNCE !");
        }
        
        if (this.bounceNumber == this.maxBounceNumber) {
            this.Stick();
        }

        if (other.collider.CompareTag("Ball")) {
            //Si l'objet est une balle
            other.gameObject.GetComponent<BallBehaviour>().Stick();
        }
        
    }

    private IEnumerator AddTimerRebound() {
        while (this.timerRebounce < this.timerRebounceMax) {
            timerRebounce += Time.deltaTime;
            yield return null;
            Debug.Log("add ta mer");
        }
    }

}
