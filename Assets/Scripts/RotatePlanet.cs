using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotateSpeed = 10;
    void Update()
    {
       this.transform.Rotate ( Vector3.up * ( rotateSpeed * Time.deltaTime ) );
    }
}
