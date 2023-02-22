using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {   Vector2 spawnPos = new Vector2(Random.Range(-9, 9), Random.Range(10, 20));
            Instantiate(enemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }
}
