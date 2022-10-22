using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationDiagonal : MonoBehaviour
{
    [SerializeField] private float amplitude = 1;
    [SerializeField] private float period = 1;

    private void Start()
    {

    }

    private void Update()
    {
        float x = amplitude * Mathf.Sin(period * Time.time);
        transform.position = new Vector3(x, x, 0);

    }
}
