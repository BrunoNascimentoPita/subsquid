using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    //private float movetime = 0.8f;

    
    public float vidaInimigo = 10f;
    public float danoSofrido = 3f;
    
    private bool dirRight;

    //private float timer;
    public float velocity = 10.0f;
    public float eixoX;

    public GameObject enemy;

    public Rigidbody rb;

    public float rotationY = 250;

    public float rotationX;

    // TIRO
    public Transform bulletEnemy;

    //public GameObject shot;
	public Transform shotSpawnEnemy;

    public float fireRate;
	private float nextFire;

    //particulas explosion
    public ParticleSystem particulaExplosaoPrefab;

    void Start () 
    {
        enemy.transform.Rotate(rotationX, rotationY, 0);
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
        //Tiro
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletEnemy, shotSpawnEnemy.position, shotSpawnEnemy.rotation);
        }
        //

        if(vidaInimigo <= 0)
        {
            GameController.instance.SetScore(10);
            GameController.instance.ContadorDeinimigos();
            Destroy(gameObject);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigo = vidaInimigo - danoSofrido;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigo = vidaInimigo - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigo = vidaInimigo - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaInimigo = vidaInimigo - 4;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaInimigo = vidaInimigo - 0.5f;
            
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("chocou com o player");
            Destroy(this.gameObject, 0.1f);
            ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
            Destroy(particulaExplosao.gameObject, 1f); // Destr�i a part�cula ap�s 1 segundo
        }

    }
}
