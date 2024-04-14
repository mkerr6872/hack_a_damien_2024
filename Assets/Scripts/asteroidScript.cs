using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 1f;
    //ranges of speed
    public float lowerSpeedX = 0.1f;
    public float upperSpeedX = 0.5f;

    //ranges of rotation
    public float lowerRotation = -2f;
    public float upperRotation = 2f;

    // Deadzones
    public float deadZoneLeft = -15f;
    public float deadZoneRight = 15f;
    public float deadZoneTop = 8f;
    public float deadzoneBot = -8f;

    //base direction
    public Vector3 direction = new Vector3(1f,1f,0f);

    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
       // moveSpeed = Random.Range(lowerSpeedX,upperSpeedX);       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (CheckDeletion()){
        Destroy(gameObject);
      }
      transform.position += Vector3.Scale(direction, new Vector3(moveSpeed,0f,0f));
      this.transform.Rotate(new Vector3(0f,0f,1f)*rotationSpeed);
    }

    void Awake()
    {
      moveSpeed = Random.Range(lowerSpeedX,upperSpeedX);
      rotationSpeed = Random.Range(lowerRotation,upperRotation);
      if (transform.position.x > 0){
        moveSpeed*=-1;
      }
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
