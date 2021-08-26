using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{   
    /*
    public float velocity = 10.0f;
    public float rotation = 90.0f;

    public float dashSpeed;

    public float dashRate;
	private float nextDash;

    */

    Rigidbody corpoRigido2D;
    public float velocidade = 50;
    

    void Start () 
    {
        corpoRigido2D = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao ();

        /*
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(0, y , x) * velocity;

        transform.Translate(dir * Time.deltaTime);

        if (Input.GetKey(KeyCode.J) && Time.time > nextDash)
        {
            nextDash = Time.time + dashRate;
            transform.Translate(dir * Time.deltaTime * dashSpeed);
            Debug.Log("Dash");
        }
        */
    }
    void Movimentacao() 
    {
      corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * velocidade, corpoRigido2D.velocity.y);
      corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * velocidade);
       
   }
}