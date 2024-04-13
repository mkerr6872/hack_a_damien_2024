using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    [Header("Physics")]
    [SerializeField] private float minForwardVelocity = 0f;
    [SerializeField] private float maxFowardVelocity = 20f;
    [SerializeField] private float rotationRate = 5f;
    [SerializeField] private float acceleration = 0.001f;

    public Vector3 ship_velocity;
    public Vector3 ship_direction;

    
    // Start is called before the first frame update
    void Start()
    {
        ship_direction = transform.up;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + ship_velocity;
        Debug.Log(ship_velocity.magnitude);


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
            ship_velocity = ship_velocity + ship_direction * acceleration;
            
        }
    }
}
