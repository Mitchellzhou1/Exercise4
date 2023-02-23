using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    int speed = 15;
    int waterSpeed = 400;
    Rigidbody2D _rigidbody2D;
    public GameObject waterPrefab;
    public Transform spawnPoint;
    // a banana is 10 points each
    // int pointValue = 10;

    public AudioClip eatSound;
    AudioSource _audioSource;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);

        // make copies of the rock
        if (Input.GetButtonDown("Jump")){
            GameObject newWater = Instantiate(waterPrefab, spawnPoint.position, Quaternion.identity);
            newWater.GetComponent<Rigidbody2D>().AddForce(new Vector3(waterSpeed, 0, 1));
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Banana")){
            _audioSource.PlayOneShot(eatSound);
            Destroy(other.gameObject);
        }
    }
}
