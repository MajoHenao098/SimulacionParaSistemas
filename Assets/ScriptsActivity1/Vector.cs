using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    [SerializeField]
    Operations first = new Operations(2, 2);
    [SerializeField]
    Operations second = new Operations(-1, 3);
    [SerializeField]
    [Range(0,1)]
    float f = 0;
    
    
    void Start()
    {
        Vector2 a = new Vector2(1,2);
        Vector2 b = new Vector2(3,4);
        Vector2 c = a + b;
        var result = first.Sumar(second);
        var result2 = first + second;
        Debug.Log(first);
    }
    private void Update()
    {
        
        var resultM = first.Multiplicar(2.0f);
        float mag = resultM.Magnitud();
        var resultD = first.Dividir(2.0f);
        //print(mag);
        var nuevo = resultM.Normalizar();
        float nuevom = nuevo.Magnitud();
        print(nuevom);
        float punto = first.Punto(second);


        first.Draw();
        second.Draw();
        var resultR = second.Restar(first);
        var resultRM = resultR.Multiplicar(f);
        resultR.Draw();
        resultRM.Draw(first);
        var otro = first.Lerp(second, f);
        otro.Draw();
        //resultD.Draw();
        //resultM.Draw();
        // first.Draw(new MyVector(2, 3));
        //resultM.Draw();

    }

    
}
