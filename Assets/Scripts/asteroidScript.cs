using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidScript : MonoBehaviour
{
    public float moveSpeedX;
    public float moveSpeedY;
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

    // sprites
    public SpriteRenderer spriteRenderer;
    public static Sprite large_b1;
    public static Sprite large_b2;
    public static Sprite med_b1;
    public static Sprite med_b2;
    public static Sprite large_g1;
    public static Sprite large_g2;
    public static Sprite med_g1;
    public static Sprite med_g2;

    public Sprite[] asteroids = {large_b1,large_b2,med_b1,med_b2,large_g1,large_g2,med_g1,med_g2};
    
    
    //scaling
    public float scaleUpperX=0.75f;
    public float scaleLowerX=1.25f;
    public float scaleUpperY=0.75f;
    public float scaleLowerY=1.25f;

    public float scaleX;
    public float scaleY;
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
      this.transform.Rotate(new Vector3(0f,0f,1f)*rotationSpeed);
    }

    void Awake()
    {
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      int i = Random.Range(0, 8);
      spriteRenderer.sprite = asteroids[i];
      moveSpeedX = Random.Range(lowerSpeedX,upperSpeedX);
      moveSpeedY = Random.Range(lowerSpeedX,upperSpeedX);
      rotationSpeed = Random.Range(lowerRotation,upperRotation);
      if (transform.position.x > 0){
        moveSpeedX*=-1;
      }
      if (transform.position.y > 0){
        moveSpeedY*=-1;
      }

      scaleX = Random.Range(scaleLowerX,scaleUpperX);
      scaleY = Random.Range(scaleLowerY,scaleUpperY);
      this.transform.localScale += new Vector3(scaleX,scaleY,0f);


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
        }
    }


}
