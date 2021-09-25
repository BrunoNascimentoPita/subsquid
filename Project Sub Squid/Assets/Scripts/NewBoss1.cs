using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoss1 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed = 8f;

    public GameObject boss1;
    public Transform posicaoDoJogador;

    public Transform posicaoDoBoss1;


    


    Animator animator;
    Rigidbody2D physics;
    SpriteRenderer sprite;

    enum State { Normal, Attack1, Attack2, Attack3}

    State state = State.Normal;
    




    void Start()
    {
        //rbEnemy = this.GetComponent<Rigidbody>();
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        posicaoDoBoss1 = GameObject.FindGameObjectWithTag("PontoDoBoss1").transform;
        //boss1.transform.Rotate(0, 260, 0);
        
    }

    void Update()
    {
        
    }


    void FixedUpdate()
    {
        
        switch (state)
        {
            case State.Normal: NormalState(); break;
            case State.Attack1: Attack1State(); break;
            case State.Attack2: Attack2State(); break;
            case State.Attack3: Attack3State(); break;
        }
    }

    void NormalState()
    {
        if (posicaoDoBoss1.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss1.position, speed * Time.deltaTime);
        }


    }

    void Attack1State()
    {
        if (posicaoDoJogador.gameObject != null)
        {
            if (boss1.transform.position.x - posicaoDoJogador.transform.position.x > posicaoDoJogador.transform.position.x)
            {
            
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, speed * Time.deltaTime);
            //enemySeguir.transform.Rotate(0, 260, 0);
            //Debug.Log("Ta indo para Esquerda");
            //VirarParaEsquerda();

                
            }

            if (boss1.transform.position.x - posicaoDoJogador.transform.position.x < posicaoDoJogador.transform.position.x)
            {
            
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, speed * Time.deltaTime);
            //enemySeguir.transform.Rotate(0, 90, 0);
            //Debug.Log("Ta indo para Direita");
            //VirarParaDireita();
            }
            //rbEnemy.velocity = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, velocidadeInimigo);
        }

    }
     

    void Awake()
    {
        animator = GetComponent<Animator>();
        physics = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    float currentAttack;
    void Attack2State()
    {
    
    
    }

    void Attack3State()
    {
    
    
    }

    
}
