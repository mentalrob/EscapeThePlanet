using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour {
    public Transform prefab;
    public float forceMultiplier = 1;
    public Vector3 offset = new Vector3(0 , 0 , 10f);
    public LineRenderer lineRenderer;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool mouseIsDown = false;

	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!mouseIsDown)
            {
                startPoint = Input.mousePosition;
                startPoint.z = 0f;
            }
            mouseIsDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition;
            endPoint.z = 0f;
            createMoon(startPoint , endPoint);
            mouseIsDown = false;
            lineRenderer.SetPosition(0 ,new Vector3(0, 0, 0));
            lineRenderer.SetPosition(1 ,new Vector3(0, 0, 0));
        }
        if (mouseIsDown)
        {
            Vector3 startPos = Camera.main.ScreenToWorldPoint(startPoint);
            Vector3 toPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            drawLine(startPos, toPos);
        }
	}

    private void drawLine(Vector3 startPos, Vector3 toPos)
    {
        lineRenderer.SetPosition(0, startPos + offset);
        lineRenderer.SetPosition(1, toPos + offset);
    }

    void createMoon(Vector3 startPoint, Vector3 endPoint) {
        Vector3 direction = startPoint - endPoint;
        direction = direction * forceMultiplier;

        Vector3 position = Camera.main.ScreenToWorldPoint(startPoint);
        position = position + offset;
        Transform moon = Instantiate(prefab, position   , transform.rotation);
        Rigidbody2D rb = moon.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }
    
}
