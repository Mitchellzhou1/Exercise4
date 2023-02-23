using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int speed = 20;
    public AudioClip shootSnd;
    public AudioClip hitSnd;
    public GameObject bulletPrefab;
    public GameObject explosion;
    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;
    GameManager _gameManager;
    Gun[] guns;
    bool shoot;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        guns = transform.GetComponentsInChildren<Gun>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);

        shoot = Input.GetButtonDown("Jump");

        if (shoot)
        {
            shoot = false;
            _audioSource.PlayOneShot(shootSnd);
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(hitSnd);
            _gameManager.MinusLife();
        }
    }
} 