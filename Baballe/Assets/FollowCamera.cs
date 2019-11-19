using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class FollowCamera : MonoBehaviour {
    public Camera cam;
    private void Start() {
        cam = Camera.main;
    }

    private void FixedUpdate() {
        transform.position = cam.transform.position + this.cam.transform.forward;
        transform.rotation = cam.transform.rotation;
    }
}
