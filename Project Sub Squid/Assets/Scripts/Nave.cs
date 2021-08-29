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
            corpoRigido2D.velocity = new Vector2 (5 * dashSpeed, 0);
            Debug.Log("Dash");
        }
        */
            // Impedir o player de sair da area da camera

        var distanceZ = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceZ)).x;

		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceZ)).y;

        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftBorder, rightBorder), Mathf.Clamp (transform.position.y, topBorder, bottomBorder), transform.position.z);

        //
    }

    void Movimentacao() 
    {
      corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * velocidade, corpoRigido2D.velocity.y);
      corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * velocidade);
    }

}