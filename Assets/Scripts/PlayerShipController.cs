using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    [Header("Physics")]
    [SerializeField] private float maxFowardVelocity = 0.2f;
    [SerializeField] private float rotationRate = 5f;
    [SerializeField] private float acceleration = 0.0025f;

    public Vector3 ship_velocity;
    public Vector3 ship_direction;
    public Vector3 ship_drift;
    
    // Start is called before the first frame update
    void Start()
    {
        ship_direction = transform.up;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug
        Debug.Log(ship_velocity.magnitude);


        // Update position based on ship_velocity vector
        transform.position = transform.position + ship_velocity;

        // Transport ship to other side of screen when out of bounds
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        }
        if (transform.position.y > 5.5f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
        }

        //Movement Controls
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0 ,0 , rotationRate) * transform.rotation;
            ship_direction = transform.up;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotationRate) * transform.rotation;
            ship_direction = transform.up;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if ((ship_velocity + ship_direction * acceleration).magnitude < 0.2f)
            {
                ship_velocity = ship_velocity + ship_direction * acceleration;
            } 
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ship_velocity *= 0.95f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if ((ship_velocity + ship_direction * acceleration).magnitude < 0.25f)
            {
                ship_drift = Quaternion.Euler(0, 0, 90) * ship_direction;
                ship_velocity = ship_velocity + ship_drift * acceleration;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if ((ship_velocity + ship_direction * acceleration).magnitude < 0.25f)
            {
                ship_drift = Quaternion.Euler(0, 0, -90) * ship_direction;
                ship_velocity = ship_velocity + ship_drift * acceleration;
            }
        }
    }
}
