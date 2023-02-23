using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana1 : MonoBehaviour
{
    int speed = 50;
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(40, 100);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Boundary")){
            Destroy(gameObject);
        }
    }
}
