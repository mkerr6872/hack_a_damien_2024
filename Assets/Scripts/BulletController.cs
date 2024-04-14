using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float bullet_speed = 2f;
    public float life_time = 3;

    public GameObject hitMarker;
    public AudioClip death_sound;

    AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = GameObject.Find("Ship").transform.position;
        direction = GameObject.Find("Ship").transform.up.normalized;
        transform.rotation = GameObject.Find("Ship").transform.rotation;
        Destroy(gameObject, life_time);

        sound = GetComponent<AudioSource>();

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
            AudioSource.PlayClipAtPoint(death_sound, transform.position);
            Instantiate(hitMarker, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        
    }
}
