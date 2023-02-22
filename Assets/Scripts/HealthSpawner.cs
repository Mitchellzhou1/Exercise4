using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPack;
    IEnumerator Start()
    {
        for (int i = 0; i < 2; i++)
        {   Vector2 spawnPos = new Vector2(12, Random.Range(-4.5f, 4.5f));
            Instantiate(healthPack, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20);
        }
    }
}
