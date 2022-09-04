using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaCayendo : MonoBehaviour
{
    [SerializeField] Camera camara;

    private MyVector2D position;

    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;

    [SerializeField] private Transform blackHole;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;

        transform.position = new Vector3(position.x, position.y, 0);
    }

    void Update()
    {
        position.Draw(Color.red);
        velocity.Draw(position, Color.green);
        acceleration.Draw(position, Color.blue);

        MyVector2D currentPosition = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D positionBlackHole = new MyVector2D(blackHole.position.x, blackHole.position.y);

        acceleration = positionBlackHole - currentPosition;
    }

}
