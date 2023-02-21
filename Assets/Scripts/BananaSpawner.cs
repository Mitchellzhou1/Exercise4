using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject banana;
    IEnumerator Start()
    {
        for (int i = 0; i < 5; i++)
        {   Vector2 spawnPos = new Vector2(Random.Range(-9, 9), Random.Range(10, 20));
            Instantiate(banana, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
}
