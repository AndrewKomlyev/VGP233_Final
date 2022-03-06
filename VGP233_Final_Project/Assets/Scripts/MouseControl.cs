using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [Flags]

    public enum RotationDirection
    {
        None,
        Horizontal =(1<<0),
        Vertical =(1<<1)
    }


    [SerializeField] private RotationDirection rotationDirections;

    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private float inputLag;
    private Vector2 rotation;
    private Vector2 speed;
    private Vector2 lastInput;
    private float inputLagTimer;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity  = GetInput()* sensitivity;

        if((rotationDirections & RotationDirection.Horizontal)==0)
        {
            velocity.x = 0;
        }

        if ((rotationDirections & RotationDirection.Vertical) == 0)
        {
            velocity.y = 0;
        }

        speed = new Vector2 (Mathf.MoveTowards(speed.x, velocity.x, acceleration.x * Time.deltaTime), Mathf.MoveTowards(speed.y, velocity.y, acceleration.y * Time.deltaTime));
        rotation += velocity * Time.deltaTime;
        rotation.y = ClampVerticleAngle(rotation.y);
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }

    private float ClampVerticleAngle(float angle)
    {
        return Mathf.Clamp(angle, -90, 90);
    }


    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer>= inputLag)
        {
            lastInput = input;
            inputLagTimer = 0;
        }

        return lastInput;
    }
}
