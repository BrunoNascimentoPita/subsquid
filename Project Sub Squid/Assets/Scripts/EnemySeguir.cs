using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeguir : MonoBehaviour
{

    //public Rigidbody rbEnemy;
    public float velocidadeInimigo;

    public float vidaInimigoSeguir = 2f;
    public float danoSofridoSeguir = 3f;

    public Transform posicaoDoJogador;
    // Start is called before the first frame update
    void Start()
    {
        //rbEnemy = this.GetComponent<Rigidbody>();
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo * Time.deltaTime);
            //rbEnemy.velocity = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo);
        }

        if(vidaInimigoSeguir <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigoSeguir = vidaInimigoSeguir - danoSofridoSeguir;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigoSeguir = vidaInimigoSeguir - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            Debug.Log("levou um tiro do player");
            vidaInimigoSeguir = vidaInimigoSeguir - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaInimigoSeguir = vidaInimigoSeguir - 4;
            
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("chocou com o player");
            Destroy(this.gameObject, 0.1f);
        }

    }

}
