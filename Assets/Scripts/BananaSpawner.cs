using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaSpawner : MonoBehaviour
{
    public GameObject banana;
    IEnumerator Start()
    {
        for (int i = 0; i < 20; i++)
        {   Vector2 spawnPos = new Vector2(10, Random.Range(-4.5f, 4.5f));
            Instantiate(banana, spawnPos, Quaternion.identity);
            Destroy(gameObject, 8);
            yield return new WaitForSeconds(8);
        }
    }
}