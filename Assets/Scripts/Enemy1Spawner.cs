using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject gorillaPrefab;

    IEnumerator Start()
    {
        for (int i = 0; i < 2000; i++) {
            Vector2 spawnPos = new Vector2(Random.Range(8.5f, 17f), Random.Range(-5, 5));
            Instantiate(gorillaPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
