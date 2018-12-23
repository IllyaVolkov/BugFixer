using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameArea;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start()
    {
        SpiderController sc = enemy.GetComponent<SpiderController>();
        sc.gameArea = this.gameArea;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
