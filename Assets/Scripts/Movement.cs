using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
       this.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
    }
}
