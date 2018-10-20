using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour {
    public Rigidbody2D rigidBody;
    public string interactWith;
    public float G = 0.02f;
    private void FixedUpdate()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(interactWith);
        foreach(GameObject go in gos){
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            if (rb == null || rb.position == rigidBody.position) continue;
            Force(go , rb);
        }
    }

    private void Force(GameObject go , Rigidbody2D rb) 
    {
        Vector2 directionVector = rigidBody.position - rb.position;
        float distance = directionVector.magnitude;
        if (distance == 0f) return;
        float force = G * (this.rigidBody.mass * rb.mass ) / Mathf.Pow(distance, 2);
        Vector2 gravityForceVector = directionVector.normalized * force;
        rigidBody.AddForce(-gravityForceVector);
    }
}
