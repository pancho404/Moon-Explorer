using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementAcceleration;
    private float maxMovementSpeed;
    private float maxDownFall;
    [SerializeField] private Vector3 downFall;
    [SerializeField] private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        maxMovementSpeed = 0.008f;
        maxDownFall = 0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = rb.mass * movementAcceleration;
        downFall.y = rb.mass * movementAcceleration;
        if (movementSpeed>=maxMovementSpeed)
        {
            movementSpeed = maxMovementSpeed;
        }
        if (downFall.y>= maxDownFall)
        {
            downFall.y = maxDownFall;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, 1f * rotationSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -1f * rotationSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * movementSpeed, ForceMode.Force);
        }
        else
        {
            rb.AddForce(-downFall, ForceMode.Force);
        }
        
       // transform.position -= downFall;
    }
}
