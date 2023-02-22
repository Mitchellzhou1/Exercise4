using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int speed = 5;
    Rigidbody2D _rigidbody2D;

    void Start()
    {    
        Destroy(gameObject, 2);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * speed;
    }
}
