using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float speed;
    public GameObject gameArea;

    private Vector3 velocity;

    void Start()
    {
        velocity = generateVelocity() * speed;
    }

    public void Update()
    {
        transform.position += velocity * Time.deltaTime;
        this.rotateTowardsVector(velocity);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == gameArea)
        {
            ContactPoint2D[] contacts = new ContactPoint2D[10];
            ContactFilter2D filter = new ContactFilter2D();
            filter.useTriggers = true;
            int contactCount = col.collider.GetContacts(filter, contacts);

            for (int i = 0; i < contactCount; i++)
            {
                ContactPoint2D contact = contacts[i];
                if (contact.collider.gameObject == this.gameObject)
                {
                    velocity = getReflectedVelocity(contact);
                    this.rotateTowardsVector(velocity);
                }
            }
        }
    }

    private Vector2 generateVelocity()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector2 vec = new Vector2(x, y);

        return Vector3.Normalize(vec);
    }

    private Vector2 getReflectedVelocity(ContactPoint2D contact)
    {
        float x = contact.point.x;
        float y = contact.point.y;
        float xPos = this.transform.position.x;
        float yPos = this.transform.position.y;
        float xVel = velocity.x;
        float yVel = velocity.y;

        if (xPos != x)
        {
            xVel = -xVel;
        }
        if (yPos != y)
        {
            yVel = -yVel;
        }
        return new Vector2(xVel, yVel);
    }

    private void rotateTowardsVector(Vector3 vector)
    {
        Vector2 v = velocity;
        float angle = Mathf.Atan2(v.x, -v.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
