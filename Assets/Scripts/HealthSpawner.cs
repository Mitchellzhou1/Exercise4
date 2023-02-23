using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPack;
    IEnumerator Start()
    {
        for (int i = 0; i < 2; i++)
        {   Vector2 spawnPos = new Vector2(10, Random.Range(-4.5f, 4.5f));
            Instantiate(healthPack, spawnPos, Quaternion.identity);
            Destroy(gameObject, 8);
            yield return new WaitForSeconds(10);
        }
    }
}
