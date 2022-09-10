using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluids : MonoBehaviour
{
    [SerializeField] Camera camara;

    private MyVector2D position;

    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private float mass = 1f;

    [Header("Forces")]
    [SerializeField] private MyVector2D wind;
    private float gravityNum = -9.8f;

    [Range(0f, 1f), SerializeField] private float DampingFactor = 0.9f;
    [Range(0f, 1f), SerializeField] private float frictionCoefficient = 0.9f;

    [SerializeField] private bool useFluidFriction;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        acceleration = new MyVector2D(0, 0);

        float weightScalar = gravityNum * mass;
        MyVector2D weight = new MyVector2D(0, weightScalar);
        MyVector2D friction = new MyVector2D(0, 0);
        ApplyForce(weight);

        if (useFluidFriction)
        {
            if (transform.localPosition.y <= 0)
            {
                float frontalArea = transform.localScale.x;
                float fluidDragCoefficient = 1;
                float velocityMagnitude = velocity.magnitude;
                float rho = 1;
                float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude * frontalArea * fluidDragCoefficient;
                MyVector2D frictionFluid = scalarPart * velocity.normalized;
                ApplyForce(frictionFluid);
            }
        }
        else
        {
            friction = frictionCoefficient * -weightScalar * velocity.normalized * -1;
            ApplyForce(weight + friction);
            weight.Draw(position, Color.yellow);
        }

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

        if (Mathf.Abs(position.x) > camara.orthographicSize)
        {
            position.x = Mathf.Sign(position.x) * camara.orthographicSize;
            velocity *= -DampingFactor;
        }

        if (Mathf.Abs(position.y) > camara.orthographicSize)
        {
            position.y = Mathf.Sign(position.y) * camara.orthographicSize;
            velocity *= -DampingFactor;
        }

        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration = force / mass;
    }
}
