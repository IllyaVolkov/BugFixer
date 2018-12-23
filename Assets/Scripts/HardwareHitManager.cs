using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwareHitManager : MonoBehaviour
{
    public GameObject errorStack;

    ErrorManager manager;

    void Awake()
    {
        manager = errorStack.GetComponent<ErrorManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SpiderHealth spiderHealth = col.gameObject.GetComponent<SpiderHealth>();

            manager.Spawn(transform);
            spiderHealth.HitTarget();
        }
    }
}
