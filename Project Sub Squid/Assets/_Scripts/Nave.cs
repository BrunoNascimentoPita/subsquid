using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nave : MonoBehaviour
{   
    /*
    public float velocity = 10.0f;
    public float rotation = 90.0f;

    */

    public float dashSpeed = 35;

     public float fireRateDash = 0.5f;
    private float nextFireDash = 0.0f;

    public static bool isDash = false;

    public float baseSpeed;

    public float dashPower;
    public float dashTime;

    public bool isDashing = false;

    // Powerups

    public static bool noPowerUp = true;
    public static bool powerUp1 = false;
    public static bool powerUp2 = false;
    public static bool powerUp3 = false;
    public static bool powerUp4 = false;

    // Tiro K

    public float fireRate;
	private float nextFire;


    
    

    Rigidbody corpoRigido2D;
    public float velocidade = 2;


    public float vidaPlayer = 10f;

    public float danoPlayer = 2f;

    // Barra de HP

    private Image BarraHp;

    // tiros novos

    Gun[] guns;
    bool shoot;

    // limites

    private Transform target;

	public bool maxMin;
	public float xMin;
	public float yMin;
	public float xMax;
	public float yMax;

    // fluido

    public float acceleration;
    public float deceleration;
 
    private Vector2 direction;
    

    void Start () 
    {
        corpoRigido2D = GetComponent<Rigidbody> ();
        //corpoRigido2D.gravityScale = 0;
        corpoRigido2D.drag = deceleration;
        direction = UnityEngine.Random.insideUnitCircle;
        BarraHp = GameObject.FindGameObjectWithTag("Hp_Barra").GetComponent<Image>();
        guns = transform.GetComponentsInChildren<Gun>();
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        velocidade = baseSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target) {
		
			transform.position = Vector3.Lerp (transform.position, target.position, velocidade) + new Vector3(0,0,target.position.z);

			if (maxMin) {
			
				transform.position = new Vector3 (Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax), 2*target.position.z);

			}
		
		}

        
        shoot = Input.GetKey(KeyCode.K);

        if(shoot && Time.time > nextFire && SpawnTiroNew.tiroPadrao == false)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                nextFire = Time.time + fireRate;
                gun.Shoot();
            }
        }

        //Movimentacao ();
    
        /*
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(0, y , x) * velocity;

        transform.Translate(dir * Time.deltaTime);

        */

        

        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!isDashing)
            {

            StartCoroutine (DashM());
            isDash = true;
            StartCoroutine ("IsDash");
                
            }
        }

        
            // Impedir o player de sair da area da camera

        /*
        var distanceZ = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).x;

		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceZ)).x;

		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceZ)).y;

        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, leftBorder, rightBorder), Mathf.Clamp (transform.position.y, topBorder, bottomBorder), transform.position.z);
        */
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

    void FixedUpdate()
    {
        //Movimentacao ();
        Vector2 directionalForce = direction * acceleration;
        corpoRigido2D.AddForce(directionalForce * Time.deltaTime, ForceMode.Impulse);
        corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * velocidade, corpoRigido2D.velocity.y);
        corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * velocidade);
    }

    IEnumerator IsDash()
    {
        yield return new WaitForSeconds (0.3f);
        isDash = false;
        
    }

    /*
    void Movimentacao() 
    {
      corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * velocidade, corpoRigido2D.velocity.y);
      corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * velocidade);
    }
    */

    IEnumerator DashM() 
    {
        Debug.Log("Dash");
        //corpoRigido2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * dashSpeed, corpoRigido2D.velocity.y);
        //corpoRigido2D.velocity = new Vector2 (corpoRigido2D.velocity.x, Input.GetAxis ("Vertical") * dashSpeed);
        isDashing = true;
        velocidade *= dashPower;

        yield return new WaitForSeconds(dashTime);
        
        velocidade = baseSpeed;
        isDashing = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TiroEnemy")
        {
            
            vidaPlayer = vidaPlayer - danoPlayer;
            CameraController.instance.CameraTremer();
            ChecarHp();
        }

        if (other.gameObject.tag == "Enemy")
        {
            
            vidaPlayer = vidaPlayer - 2;
            CameraController.instance.CameraTremer();
            ChecarHp();
        }

        if (other.gameObject.tag == "Boss1")
        {
            
            vidaPlayer = vidaPlayer - 5;
            CameraController.instance.CameraTremer();
            ChecarHp();
        }

        if (other.gameObject.tag == "PowerUpVida")
        {
            
            vidaPlayer = vidaPlayer + 2;
            ChecarHp();
        }

        if (other.gameObject.tag == "PW1")
        {
            
            noPowerUp = false;
            powerUp1 = true;
            powerUp2 = false;
            powerUp3 = false;
            StartCoroutine ("NoPowerUps");

        }

        if (other.gameObject.tag == "PW2")
        {
            
            noPowerUp = false;
            powerUp1 = false;
            powerUp2 = true;
            powerUp3 = false;
            StartCoroutine ("NoPowerUps");
        }

        if (other.gameObject.tag == "PW3")
        {
            
            noPowerUp = false;
            powerUp1 = false;
            powerUp2 = false;
            powerUp3 = true;
            StartCoroutine ("NoPowerUps");
        }

        if (other.gameObject.tag == "PW3")
        {
            
            noPowerUp = false;
            powerUp1 = false;
            powerUp2 = false;
            powerUp3 = true;
            StartCoroutine ("NoPowerUps");
            
        }
        if (other.gameObject.tag == "PW4")
        {

            noPowerUp = false;
            powerUp1 = false;
            powerUp2 = false;
            powerUp3 = false;
            powerUp4 = true;
            StartCoroutine("NoPowerUps");

        }

    }

    void ChecarHp()
    {
        
        float vida_paraBarra = vidaPlayer * 10;
        BarraHp.rectTransform.sizeDelta = new Vector2(vida_paraBarra, 7 );
    }

    IEnumerator NoPowerUps()
    {
         yield return new WaitForSeconds (5.0f);
            noPowerUp = true;
            powerUp1 = false;
            powerUp2 = false;
            powerUp3 = false;
            powerUp4 = false;
    }
    
}