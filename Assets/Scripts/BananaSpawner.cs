using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject banana;
    IEnumerator Start()
    {
        for (int i = 0; i < 50; i++)
        {   
            Vector2 spawnPos = new Vector2(Random.Range(8.5f, 17f), Random.Range(-5, 5));
            Instantiate(banana, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
