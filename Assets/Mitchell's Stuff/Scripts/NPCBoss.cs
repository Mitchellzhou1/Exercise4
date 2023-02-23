using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBoss : MonoBehaviour
{

    public int health;
    int bulletSpeed = -300;
    public float fireRate;
    Rigidbody2D _rigidbody2D;


    public GameObject explosion;
    public GameObject banana;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    GameManager _gameManager;

    void Start()
    {
        InvokeRepeating("Shoot", fireRate, fireRate);
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("PlayerBullet")){
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Instantiate(banana, transform.position, Quaternion.identity);
            }
        }

        if (other.CompareTag("Player")){
            _gameManager.MinusLife();
        }
        


    }
    
    void Shoot(){
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
    }
}