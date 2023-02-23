using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float rate;
    public int speed;
    public GameObject[] enemies;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int Start_Posistion_X = 9;
        float Start_Posistion_Y = Random.Range(-4.5f, 4.5f);

        GameObject gorilla = Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Start_Posistion_X, Start_Posistion_Y, 0), Quaternion.identity);
        gorilla.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
        Destroy(gameObject, 8);
    
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("NPCBullet") || other.CompareTag("PlayerBullet")){
            Destroy(other.gameObject);
        }
    }
}
