using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoss1 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed = 8f;
     [SerializeField] float speedAttack = 16f;

    public GameObject boss1;
    private Transform posicaoDoJogador;

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
        Debug.Log("State normal");
        if (posicaoDoBoss1.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss1.position, speed * Time.deltaTime);
        }

        StartCoroutine ("TrocarStateAttack1");
    }

    IEnumerator TrocarStateAttack1()
    {
        yield return new WaitForSeconds (1.0f);
        state = State.Attack1;

        
    }

    IEnumerator VoltarNormalState()
    {
        yield return new WaitForSeconds (1.0f);
        state = State.Normal;

        
    }

    void Attack1State()
    {
        Debug.Log("State attack1");

        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, speedAttack * Time.deltaTime);
        }

        StartCoroutine ("VoltarNormalState");

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
