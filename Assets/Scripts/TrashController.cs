using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public Camera cam;
    public int catchedScore;

    float maxWidth;
    Rigidbody2D rd2D;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        rd2D = GetComponent<Rigidbody2D>();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x;
    }

    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, transform.position.y, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        rd2D.MovePosition(targetPosition);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Error")
        {
            ScoreManager.score += catchedScore;
        }
    }
}
