using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public Rigidbody2D rb;
    public float forceMultiplier = 1f;
    public float rotationMultiplier = 2f;
    private bool flying = false;
    private float rotation = 0f;
    void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            flying = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            flying = false;
        }
        rotation = Input.GetAxisRaw("Horizontal");
	}

    private void FixedUpdate()
    {
        if (flying)
        {
            Vector2 direction = transform.up;
            rb.velocity = (direction * forceMultiplier);
        }
        if (rotation == 1f) transform.Rotate(Vector3.back * rotationMultiplier);
        if (rotation == -1f) transform.Rotate(Vector3.forward * rotationMultiplier);
    }
}
