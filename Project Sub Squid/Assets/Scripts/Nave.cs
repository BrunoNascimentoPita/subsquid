using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{   
    /*
    public float velocity = 10.0f;
    public float rotation = 90.0f;

    */

    public float dashSpeed = 35;

    public float dashRate;
	private float nextDash;
    

    Rigidbody corpoRigido2D;
    public float velocidade = 2;


    public float vidaPlayer = 5f;

    public float danoPlayer = 2f;
    

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

        */



        if (Input.GetKey(KeyCode.U) && Time.time > nextDash)
        {
            DashM();
        }

        
            // Impedir o player de sair da area da camera

        var distanceZ = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceZ)).x;

		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceZ)).y;

        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftBorder, rightBorder), Mathf.Clamp (transform.position.y, topBorder, bottomBorder), transform.position.z);

        //

        if(vidaPlayer <= 0)
        {
            Time.timeScale = 0;
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            GameController.instance.ShowPauseTela();
        }
    }

    void Movimentacao() 
    {
      corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * velocidade, corpoRigido2D.velocity.y);
      corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * velocidade);
    }

    void DashM() 
    {
        Debug.Log("Dash");
      corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * dashSpeed, corpoRigido2D.velocity.y);
      corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * dashSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiroEnemy")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaPlayer = vidaPlayer - danoPlayer;
            CameraController.instance.CameraTremer();
        }
    }

}