using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    //private float movetime = 0.8f;

    private bool dirRight;

    //private float timer;
    public float velocity = 10.0f;
    public float eixoX;

    public GameObject enemy;

    public Rigidbody rb;

    public float rotationY = 260;

    void Start () 
    {
        enemy.transform.Rotate(0, rotationY, 0);
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(-speed, 0, 0);
        /*
        if(dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        
        /*timer += Time.deltaTime;
        if(timer >= movetime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
        */
    }
}
