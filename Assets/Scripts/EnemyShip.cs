using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float moveSpeedX;
    public float moveSpeedY;
    public float rotationSpeed = 1f;
    //ranges of speed
    public float lowerSpeedX = 0.1f;
    public float upperSpeedX = 0.2f;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (CheckDeletion()){
        Destroy(gameObject);
      }
      transform.position += Vector3.Scale(direction, new Vector3(moveSpeedX,moveSpeedY,0f));
    }

    void Awake()
    {
      moveSpeedX = Random.Range(lowerSpeedX,upperSpeedX);
      moveSpeedY = Random.Range(lowerSpeedX,upperSpeedX);
      if (transform.position.x > 0){
        moveSpeedX*=-1;
      }
      if (transform.position.y > 0){
        moveSpeedY*=-1;
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
