using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject gorillaPrefab;

    IEnumerator Start()
    {
        for (int i = 0; i < 2000; i++) {
            Vector2 spawnPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-10, 10));
            Instantiate(gorillaPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.4f);
        }
    }
}
