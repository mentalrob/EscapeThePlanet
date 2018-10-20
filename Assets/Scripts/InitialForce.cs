using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialForce : MonoBehaviour {
    public Rigidbody2D rb;
    public Vector3 force;
    public float forceMultiplier;
    void Start () {
        rb.AddForce(force * forceMultiplier);		
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + force);
    }
}
