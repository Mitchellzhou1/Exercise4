using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    int speed = 50;
    // taking down a gorilla is 50 points each
    int pointValue = 50;
    // beaten by a gorilla is -200 each
    int harm = -200;

    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    public AudioClip goanSound;
    AudioSource _audioSource;

    void Start()
    {
        speed = Random.Range(40, 100);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // _rigidbody2D.AddForce(new Vector2(0, -speed));
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
        _audioSource = GetComponent<AudioSource>();
    }

    // OnTriggerEnter() calls when a trigger and a regular collider (or another trigger with rigid body) hit each other
    // OnCollisionEnter() calls when two colliders hit each other
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Water")){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.CompareTag("Boundary")){
            Destroy(gameObject);
        }

        if(other.CompareTag("Player")){
            _audioSource.PlayOneShot(goanSound);
        }
    }
}
