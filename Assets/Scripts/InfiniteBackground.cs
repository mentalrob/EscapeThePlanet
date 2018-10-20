using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {
    public Camera camera;
    public Transform background;
    public Vector3 offset = new Vector3(0,0,10);

    private float cameraLeftX;
    private float cameraRightX;
    private float cameraTopY;
    private float cameraBottomY;

    private float backgroundLeftX;
    private float backgroundRightX;
    private float backgroundTopY;
    private float backgroundBottomY;
    private void Start()
    {
        updateBackgroundBounds();
    }
    void Update () {
        updateCameraBounds();
        if (cameraOutOfBackgroundBounds())
        {
            background.transform.position = camera.transform.position + offset;
            updateBackgroundBounds();
        }
    }
    
    bool cameraOutOfBackgroundBounds()
    {
        if (cameraLeftX <= backgroundLeftX) return true;
        if (cameraRightX >= backgroundRightX) return true;
        if (cameraTopY >= backgroundTopY) return true;
        if (cameraBottomY <= backgroundBottomY) return true;

        return false;
    }


    void updateCameraBounds()
    {
        cameraLeftX = camera.transform.position.x - camera.orthographicSize;
        cameraRightX = camera.transform.position.x + camera.orthographicSize;
        cameraTopY = camera.transform.position.y + camera.orthographicSize;
        cameraBottomY = camera.transform.position.y - camera.orthographicSize;
    }

    void updateBackgroundBounds()
    {
        backgroundLeftX = background.transform.position.x - background.transform.localScale.x / 2;
        backgroundRightX = background.transform.position.x + background.transform.localScale.x / 2;
        backgroundTopY = background.transform.position.y + background.transform.localScale.y / 2;
        backgroundBottomY = background.transform.position.y - background.transform.localScale.y / 2;
    }
}
