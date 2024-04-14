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
    
    public Vector3 velocity = new Vector3(1f,1f,0f);
    public GameObject GameObject;

    //pass through 
    public bool pass = false;

    // chase velocity
    public float chaseSpeed = 0.09f;
    public float chaseGap = 4f;
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
      
      GameObject ship = UnityEngine.GameObject.FindGameObjectWithTag("Player");
      //What is the difference in position?
      Vector3 diff = (ship.transform.position - transform.position);
      Debug.Log(diff.magnitude); 
      if (diff.magnitude > chaseGap && pass == false){
        velocity = diff.normalized*chaseSpeed;
        transform.position += Vector3.Scale(direction,velocity);
        
      } else
      {
        
        transform.position += Vector3.Scale(direction,velocity);

        pass = true;
      }

      //We use aTan2 since it handles negative numbers and division by zero errors. 
      // float angle = Mathf.Atan2(diff.x, diff.y);

      // Now we set our new rotation. 
      // transform.Rotate(0f, 0f, angle*Mathf.Min(1f,diff.magnitude));
      // Debug.Log(diff.magnitude);
      // transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z*diff.magnitude);
      // Debug.Log(transform.rotation.z);
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

      velocity = new Vector3(moveSpeedX,moveSpeedY,0f);

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
