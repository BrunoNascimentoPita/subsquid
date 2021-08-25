using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocity = 10.0f;
    public float rotation = 90.0f;
    

    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirEnemy = new Vector3(-velocity, 0 , 0) * velocity;

        transform.Translate(dirEnemy * Time.deltaTime);
    }
}
