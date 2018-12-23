using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSpawner : MonoBehaviour
{
    public Camera cam;
    public GameObject error;
    public float spawnTime = 3f;
    float maxWidth;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(error, spawnPosition, spawnRotation);
    }
}
