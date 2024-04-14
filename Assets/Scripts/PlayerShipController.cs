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
    [SerializeField] private int fireCooldown = 25;

    public Vector3 ship_velocity;
    public Vector3 ship_direction;
    public Vector3 ship_drift;

    public int fire_timer;
    public bool can_fire;
    public bool is_boosting;
    public bool boost_sound;
    

    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    public AudioClip gun_fire;
    public AudioClip ship_explosion;
    public AudioClip rocket_engine;

    AudioSource sound;
    SpriteRenderer picture;
    SpriteRenderer engine_anim;

    // Start is called before the first frame update
    void Start()
    {
        ship_direction = transform.up;
        fire_timer = 0;
        can_fire = true;
        sound = GetComponent<AudioSource>();
        picture = GetComponent<SpriteRenderer>();
        engine_anim = GameObject.Find("engine_flames").GetComponent<SpriteRenderer>();
        picture.enabled = true;
        is_boosting = false;
        boost_sound = false;
        engine_anim.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            is_boosting = false;
        }

    }

    void FixedUpdate()
    {
        //Debug


        // Engine Noise Check
        engineSound();


        // Gun cooldown
        if (can_fire == false)
        {
            fire_timer += 1;
        }

        if (fire_timer > fireCooldown)
        {
            can_fire = true;
        }


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
            is_boosting = true;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            ship_velocity *= 0.95f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if ((ship_velocity + ship_direction * acceleration).magnitude < maxFowardVelocity)
            {
                ship_drift = Quaternion.Euler(0, 0, 90) * ship_direction;
                ship_velocity = ship_velocity + ship_drift * acceleration;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            if ((ship_velocity + ship_direction * acceleration).magnitude < maxFowardVelocity)
            {
                ship_drift = Quaternion.Euler(0, 0, -90) * ship_direction;
                ship_velocity = ship_velocity + ship_drift * acceleration;
            }
        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (can_fire == true)
            {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                sound.PlayOneShot(gun_fire, 1);
                can_fire = false;
                fire_timer = 0;
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "asteroid(Clone)")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            sound.PlayOneShot(ship_explosion, 1);
            picture.enabled = false;
            Destroy(gameObject, 2);
        }
    }

    private void engineSound()
    {
        if (is_boosting == true && boost_sound == false)
        {
                sound.Play(0);
                boost_sound = true;
                engine_anim.enabled = true;
        }
        if (is_boosting == false && boost_sound == true)
        {
            sound.Stop();
            boost_sound = false;
            engine_anim.enabled = false;
        }
    }
}
