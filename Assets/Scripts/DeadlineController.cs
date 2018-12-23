using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineController : MonoBehaviour
{
    public GameObject errorStack;

    ErrorManager manager;

    void Awake()
    {
        manager = errorStack.GetComponent<ErrorManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Error")
        {
            manager.Spawn();
        }
    }
}
