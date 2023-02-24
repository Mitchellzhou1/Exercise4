using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float rate;
    public int speed;
    public int requiredPoints;
    public GameObject[] enemies;
    bool flag = true;

    GameManager _gameManager;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int Start_Posistion_X = 12;
        float Start_Posistion_Y = Random.Range(-4.5f, 4.5f);

        if (_gameManager.getScore() >= requiredPoints){
            if (flag && enemies[0].CompareTag("NPCBoss")){
                GameObject NPCBoss = Instantiate(enemies[0], new Vector3(Start_Posistion_X-4, 0, 0), Quaternion.identity);
                //NPCBoss.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, -speed));
                flag = false; 
            }   
        }
        else if (!enemies[0].CompareTag("NPCBoss")){
            GameObject gorilla = Instantiate(enemies[0], new Vector3(Start_Posistion_X, Start_Posistion_Y, 0), Quaternion.identity);
            gorilla.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));    
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (!(other.CompareTag("enemy") || other.CompareTag("NPCBoss") || other.CompareTag("BossAttack") 
            || other.CompareTag("Bomb") || other.CompareTag("Health"))) {
            Destroy(other.gameObject);
        }
    }
}

