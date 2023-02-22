using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    int speed;

    // int pointValue = 1;

    public GameObject explosion;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    void Start()
    {
        speed = Random.Range(50,200);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
