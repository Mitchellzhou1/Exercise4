using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    int speed = 10;
    public AudioClip shootSnd;
    public AudioClip hitSnd;
    public AudioClip bananaSnd;
    public AudioClip powerUpSnd;
    public GameObject explosion;
    public GameObject bulletPrefab;
    public Transform spawnPointL;
    public Transform spawnPointR;
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

        if (other.CompareTag("Banana"))
        {
            _audioSource.PlayOneShot(bananaSnd);
            _gameManager.AddScore();
        }

        if (other.CompareTag("Health"))
        {
            _audioSource.PlayOneShot(powerUpSnd);
            _gameManager.AddLife();
        }

        if (other.CompareTag("Bomb"))
        {
            _audioSource.PlayOneShot(powerUpSnd);
            InvokeRepeating("Shoot", 0, 0.1f);
            StartCoroutine("StopShoot");
            
        }
    }

    void Shoot()
    {

        _audioSource.PlayOneShot(shootSnd);
        GameObject rBullet = Instantiate(bulletPrefab, spawnPointR.position, Quaternion.identity);
        rBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));

        GameObject lBullet = Instantiate(bulletPrefab, spawnPointL.position, Quaternion.identity);
        lBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
        Destroy(rBullet, 5);
        Destroy(lBullet, 5);
    }

    IEnumerator StopShoot(){
        yield return new WaitForSeconds(2);
        CancelInvoke();
    }
} 