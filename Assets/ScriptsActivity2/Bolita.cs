using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] Camera camara;

    private MyVector2D position;

    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;


    [Range(0f, 1f)] [SerializeField] private float dampingFactor;

    private int currentAcceleration = 0;

    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
        
        new MyVector2D(0, -9.8f), //abajo

        new MyVector2D(9.8f, 0), //derecha

        new MyVector2D(0, 9.8f), //arriba

        new MyVector2D(-9.8f, 0) //izquierda
    };

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; 

        if (Mathf.Abs(position.x) > camara.orthographicSize)
        {
            velocity.x = velocity.x * -1;
            position.x = Mathf.Sign(position.x) * camara.orthographicSize;
            velocity *= dampingFactor;
        }

        if (Mathf.Abs(position.y) > camara.orthographicSize)
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camara.orthographicSize;
            velocity *= dampingFactor;
        }

        transform.position = new Vector3(position.x, position.y);
    }

    void Update()
    {

        position.Draw(Color.green);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(currentAcceleration++) % directions.Length];
            velocity *= 0;
        }
    }
}