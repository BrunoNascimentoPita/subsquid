using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    [SerializeField]
    //private float speed = 2f;

    
    public float vidaBoss2 = 1000.0f;
    public float danoBoss2 = 3.0f;
    

    //private float timer;
    public float speed = 10.0f;
    public float eixoX;

    public GameObject boss2;

    public Rigidbody rbBoss2;

    public float rotationY = 250;

    public float rotationX;

    private Transform player;

    public Transform posicaoDoBoss2;

    public Material[] materialBoss;

    public Color danoCor;

    public float timeCorDano = 0.01f;

    void Start()
    {
        rbBoss2 = this.GetComponent<Rigidbody>();
        posicaoDoBoss2 = GameObject.FindGameObjectWithTag("PontoDoBoss2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoDoBoss2.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss2.position, speed * Time.deltaTime);
        }

        if(vidaBoss2 <= 0)
        {
            GameController.instance.SetScore(100);
            GameController.instance.ShowWinTela();
            SpawnEnemy.boss2NaCena = false;
            SpawnEnemy.boss2JaMorreu = true;
            Destroy(gameObject);
        }
    }

    IEnumerator DanoCor()
    {
        GetComponent<Renderer>().materials[0].color = danoCor;

        yield return new WaitForSeconds(timeCorDano);

        GetComponent<Renderer>().materials[0].color = materialBoss[0].color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do player");
            vidaBoss2 = vidaBoss2 - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do playerr");
            vidaBoss2 = vidaBoss2 - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do playerr");
            vidaBoss2 = vidaBoss2 - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss2 levou um tiro do player");
            vidaBoss2 = vidaBoss2 - 4;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            StartCoroutine(DanoCor());
            Debug.Log("lBoss2 levou um tiro do player");
            vidaBoss2 = vidaBoss2 - 1f;
            
        }

    }
}
