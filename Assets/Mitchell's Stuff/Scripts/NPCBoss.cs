using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBoss : MonoBehaviour
{

    public int health;
    int bulletSpeed = -300;
    public float fireRate;
    Rigidbody2D _rigidbody2D;


    public GameObject explosion;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    GameManager _gameManager;

    Transform point1, point2;
    public float movespeed = 1f;
    
    Vector3 localScale;
    bool moveUp = true;
    Rigidbody2D rb;

    void Start()
    {
        InvokeRepeating("Shoot", fireRate, fireRate);
        _gameManager = GameObject.FindObjectOfType<GameManager>();


        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        point1 = GameObject.Find("point1").GetComponent<Transform>();
        point2 = GameObject.Find("point2").GetComponent<Transform>();



    }

    void Update(){
        if (transform.position.y > point1.position.y){
            moveUp = false;
        }
        if (transform.position.y < point2.position.y){
            moveUp = true;
        }

        if (moveUp)
            moveUp1();
        else
            moveDown1();
    }  


    void moveUp1(){      // move up
        moveUp = true;
        transform.localScale = localScale;
        //rb.velocity = new Vector2(localScale.x * movespeed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, localScale.y * movespeed);
    }

    void moveDown1(){
        moveUp = false;
        transform.localScale = localScale;
        rb.velocity = new Vector2(rb.velocity.x, localScale.y * -movespeed);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("PlayerBullet")){
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                SceneManager.LoadScene("Victory");
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