using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Gravity target;
    public float mass = 1f;

    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        acceleration *= 0;

        MyVector2D atrac = target.position - position;
        float atracMag = atrac.magnitude;
        MyVector2D force = atrac.normalized * (target.mass / atracMag * atracMag);
        ApplyForce(force);
        force.Draw(position, Color.white);

        Move();
    }

    void Update()
    {
        velocity.Draw(position, Color.green);

        acceleration.Draw(position, Color.black);

        position.Draw(Color.blue);
    }

    public void Move()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        if (velocity.magnitude > 5)
        {
            velocity.Normalized();
            velocity *= 5;
        }

        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }
}
