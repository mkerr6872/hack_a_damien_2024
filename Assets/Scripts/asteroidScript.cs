using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 1f;
    //ranges of speed
    public float lowerSpeed = 0.005f;
    public float upperSpeed = 0.01f;

    //ranges of rotation
    public float lowerRotation = -2f;
    public float upperRotation = 2f;

    // Deadzones
    public float deadZoneLeft = -15f;
    public float deadZoneRight = 15f;
    public float deadZoneTop = 7f;
    public float deadzoneBot = -7f;
    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
       moveSpeed = Random.Range(lowerSpeed,upperSpeed);       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (CheckDeletion()){
        Destroy(gameObject);
      }
      transform.position += (Vector3.left * moveSpeed);
      this.transform.Rotate(new Vector3(0f,0f,1f)*rotationSpeed);
    }

    void Awake()
    {
      moveSpeed = Random.Range(lowerSpeed,upperSpeed);
      rotationSpeed = Random.Range(lowerRotation,upperRotation);
    }

    bool CheckDeletion(){
      if (deadZoneLeft < transform.position.x && transform.position.x < deadZoneRight)
      {
        if (deadzoneBot < transform.position.y && transform.position.y < deadZoneTop){
          return false;
        }

      }
      return true;

    }
}
