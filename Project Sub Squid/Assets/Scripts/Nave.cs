using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float velocity = 10.0f;
    public float rotation = 90.0f;
    

    void Start () 
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(0, z , x) * velocity;

        transform.Translate(dir * Time.deltaTime);

    }
}