using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public int damage = 10;

    Rigidbody2D rd2D;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        rd2D = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(rawPosition.x, rawPosition.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProcessMouseDown();
        }
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }

    public void ProcessMouseDown()
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[10];
        int contacts = rd2D.GetContacts(contactPoints);
        for (int i = 0; i < contacts; i++)
        {
            GameObject obj = contactPoints[i].collider.gameObject;
            DamageObject(obj);
        }
    }

    void DamageObject(GameObject obj)
    {
        if (obj.tag == "Enemy")
        {
            SpiderHealth spiderHealth = obj.GetComponent<SpiderHealth>();

            spiderHealth.TakeDamage(damage);
        }
    }
}
