using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidScript : MonoBehaviour
{
    public float moveSpeed =0.1f;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (Vector3.left * moveSpeed);
        this.transform.Rotate(new Vector3(0f,0f,1f));
    }
}
