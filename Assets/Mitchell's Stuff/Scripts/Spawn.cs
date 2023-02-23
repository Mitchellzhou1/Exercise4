using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float rate;
    public int speed;
    public GameObject[] enemies;
    public GameObject Boss;

    GameManager _gameManager;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int Start_Posistion_X = 9;
        float Start_Posistion_Y = Random.Range(-4.5f, 4.5f);
        bool keepSpawning = true;
        //int count = 0;

        // if (enemies[0].CompareTag("NPCBoss") && score)
<<<<<<< HEAD
        if (_gameManager.getScore() >= requiredPoints){
            keepSpawning = false;    
        }

        // if (keepSpawning && count == 0){
        //     GameObject NPCBoss = Instantiate(Boss, new Vector3(-10, 0, 0), Quaternion.identity);
        //     count += 1;
        // }
        if (keepSpawning){
=======
        if (_gameManager.getScore() >= 3){
            activeBoss = true;    
        }

        if (activeBoss && count == 0){
            GameObject NPCBoss = Instantiate(Boss, new Vector3(-10, 0, 0), Quaternion.identity);
            count += 1;
        }
        else if (!activeBoss){
            print("This ran");
>>>>>>> parent of 75569a2 (fix some merging issues)
            GameObject gorilla = Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Start_Posistion_X, Start_Posistion_Y, 0), Quaternion.identity);
            gorilla.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));    
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("NPCBullet") || other.CompareTag("PlayerBullet")){
            Destroy(other.gameObject);
        }
    }
}
