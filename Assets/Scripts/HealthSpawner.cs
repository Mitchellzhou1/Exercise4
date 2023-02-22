using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPack;
    IEnumerator Start()
    {
        for (int i = 0; i < 2; i++)
        {   Vector2 spawnPos = new Vector2(Random.Range(-9, 9), Random.Range(10, 20));
            Instantiate(healthPack, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
        }
    }
}
