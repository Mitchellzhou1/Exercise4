using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    int speed = 200;
    int health = 3;
    int bulletSpeed = 300;
    public AudioClip hitSnd;
    public GameObject explosion;
    public GameObject banana;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;

    void Start()
    {
        Destroy(gameObject, 30);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -speed));
        _audioSource = GetComponent<AudioSource>();

        InvokeRepeating("Shoot", 2, 3);

    }

    void Shoot(){
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
        Destroy(newBullet, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            _audioSource.PlayOneShot(hitSnd);
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0)
            {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Instantiate(banana, transform.position, Quaternion.identity);
            }
        }
        if (other.CompareTag("Player"))
        {
            {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            }
        }
    }

}