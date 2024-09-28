using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// "How to pick up / drop objects - Unity Tutorial" by Benjamin Knower on YouTube

public class BasicPickUp : MonoBehaviour {
    
    private GameObject heldObject;

    // radius from object that player is able to grab it
    public float radius = 0.5f;

    // distance and height the object is held from player
    public float distance = 0f;
    public float height = 0f;

    private void Update() {
        
            var t = transform;
            var pressedLeftMouse = Input.GetKeyDown(KeyCode.Mouse0);
            
            // var pressedE = Input.GetKeyDown(KeyCode.E);

        // while holding object
        if (heldObject) {

            // to throw the object while holding it, press Left Mouse
            if (pressedLeftMouse) {

                var rigidBody = heldObject.GetComponent<Rigidbody>();

                // default drag and gravity
                rigidBody.drag = 1f;
                rigidBody.useGravity = true;

                // object no longer held
                heldObject = null;

            }

        } else {

            // to pick up a pick up-able object, click Left Mouse
            if (pressedLeftMouse) {

                var hits = Physics.SphereCastAll(t.position + t.forward, radius, t.forward, radius);
                var hitIndex = Array.FindIndex(hits, hit => hit.transform.tag == "AbleToGrab");

                if (hitIndex != -1) {

                    var hitObject = hits[hitIndex].transform.gameObject;
                    heldObject = hitObject;

                     var rigidBody = heldObject.GetComponent<Rigidbody>();
                     rigidBody.drag = 25f;
                     rigidBody.useGravity = false;

                }

            }

        }

    }

    private void FixedUpdate() {

            var t = transform;
            var rigidBody = heldObject.GetComponent<Rigidbody>();
            var moveTo = t.position + distance * t.forward + height * t.up;
            var difference = moveTo - heldObject.transform.position;

            rigidBody.AddForce(difference * 500);

            heldObject.transform.rotation = t.rotation;

            // comment

    }

}
