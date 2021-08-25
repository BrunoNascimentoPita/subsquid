using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocity = 10.0f;
    public float eixoX;
    public float eixoZ;
    

    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 dir = new Vector3(0, eixoZ , eixoX) * velocity;

        transform.Translate(dir * Time.deltaTime);
    }
}
