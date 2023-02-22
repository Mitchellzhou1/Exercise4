using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bomb;
    IEnumerator Start()
    {
        for (int i = 0; i < 3; i++)
        {   Vector2 spawnPos = new Vector2(12, Random.Range(-4.5f, 4.5f));
            Instantiate(bomb, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(15);
        }
    }
}
