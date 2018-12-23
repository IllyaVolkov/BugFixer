using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingErrorController : MonoBehaviour
{
    public float speed;

    private Vector3 velocity;

    void Start()
    {
        velocity = new Vector3(0, -1.0f, 0.0f) * speed;
    }

    public void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject, 0.0f);
    }
}
