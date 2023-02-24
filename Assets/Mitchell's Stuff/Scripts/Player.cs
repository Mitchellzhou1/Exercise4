using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static Player instance;
    public GameObject explosion;
    int speed = 10;
    int bulletSpeed = 600;
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    GameManager _gameManager;

    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);

        if (Input.GetButtonDown("Jump")){
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bulletSpeed, 0, 1));
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("NPCBullet") || other.CompareTag("enemy")){
            Destroy(other.gameObject);
            _gameManager.MinusLife();
        }
        else if (other.CompareTag("Finish")){
            //print("You got hit by the BossAttack");
            _gameManager.GGz();
            GameOver();
        }
        else if (other.CompareTag("Banana")){
            Destroy(other.gameObject);
            _gameManager.AddScore();
        }
        else if (other.CompareTag("Health")){
            Destroy(other.gameObject);
            _gameManager.AddLife();
        }
        else if (other.CompareTag("Bomb")){
            Destroy(other.gameObject);
            _gameManager.AddLife();
        }
    }

    public void GameOver()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}