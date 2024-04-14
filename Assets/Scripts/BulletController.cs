using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float bullet_speed = 2f;
    public float life_time = 3;

    public Sprite hitMarker;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = GameObject.Find("Ship").transform.position;
        direction = GameObject.Find("Ship").transform.up.normalized;
        transform.rotation = GameObject.Find("Ship").transform.rotation;
        Destroy(gameObject, life_time);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + direction*bullet_speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "asteroid(Clone)")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hitMarker;
            transform.localScale = new Vector3(2, 2, 2);
            bullet_speed = 0;
            Destroy(gameObject, 0.5f);
            Debug.Log("Hit");
        }
        
    }
}
