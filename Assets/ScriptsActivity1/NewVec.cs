using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVec : MonoBehaviour
{
    [SerializeField] MyVector2D vector1, vector2;
    [Range(0f, 1f)] public float range;


    void Update()
    {

        vector1.Draw(Color.blue);
        vector2.Draw(Color.red);

        MyVector2D vector3 = (vector2 - vector1) * range;
        MyVector2D vector4 = vector1 + vector3;

        vector3.Draw(Color.green);
        vector3.Draw(vector1, Color.green);
        vector4.Draw(Color.white);
    }
}
