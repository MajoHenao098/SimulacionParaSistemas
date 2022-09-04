using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    [SerializeField] Camera camara;

    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;

    private MyVector2D position;
    private MyVector2D displacement;

    [Range(0f, 1f)] [SerializeField] private float dampingFactor;

    private int currentAcceleration = 0;

    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
        
        //Direcciones para moverse 
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
        Move();
    }

    // Update is called once per frame
 

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
    public void Move()
    {
        //Euler integrator
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; //(1f / 60f) time.delta time representa esta division 

        //check horizontal bounds
        if (Mathf.Abs(position.x) > camara.orthographicSize)
        {
            velocity.x = velocity.x * -1;
            position.x = Mathf.Sign(position.x) * camara.orthographicSize;
            //Mathf.Sign devuelve 1(positivo) 0 -1(negativo) dependiendo del signo 
            velocity *= dampingFactor;
        }

        //check vertical bounds
        if (Mathf.Abs(position.y) > camara.orthographicSize)
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camara.orthographicSize;
            velocity *= dampingFactor;
        }

        //CheckBounds(ref position.x, ref displacement.x, camara.orthographicSize);
        //CheckBounds(ref position.y, ref displacement.y, camara.orthographicSize);

        transform.position = new Vector3(position.x, position.y);//referenciar el mov de la bolita para que se mueva con los vectores
    }
}
