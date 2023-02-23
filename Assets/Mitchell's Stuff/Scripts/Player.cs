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

    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update

    private void Awake(){
        instance = this;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (other.CompareTag("NPCBullet")){
            Destroy(other.gameObject);
            //ScoreManager.instance.loseHealth(1);
        }
        else if (other.CompareTag("Banana")){
            Destroy(other.gameObject);
            // Add points;
        }
        else if (other.CompareTag("Health")){
            Destroy(other.gameObject);
            // Add Health;
        }
    }

    // public void GameOver(int score)
    // {
    //     Instantiate(explosion, transform.position, Quaternion.identity);
    //     GameObject.Find("GameManager").GetComponent<GameManager>().isDead = true;
    //     Destroy(gameObject);
    // }

}