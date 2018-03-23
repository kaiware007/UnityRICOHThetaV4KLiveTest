using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 rotationSpeed;
    public bool reverse;
    private Vector2 lastMousePosition;
    private Vector2 newAngle = new Vector2(0, 0);

    void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            newAngle = mainCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y * dt;
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x * dt;
                mainCamera.transform.localEulerAngles = newAngle;
                lastMousePosition = Input.mousePosition;
            }
            else if (reverse)
            {
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * rotationSpeed.y * dt;
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y) * rotationSpeed.x * dt;
                mainCamera.transform.localEulerAngles = newAngle;
                lastMousePosition = Input.mousePosition;
            }
        }
    }
}