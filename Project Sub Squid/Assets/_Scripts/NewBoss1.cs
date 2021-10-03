using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBoss1 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed = 8f;
    [SerializeField] float speedAttack = 16f;
    [SerializeField] float attack1Duration = 1.0f;
    [SerializeField] float stateNormalDuration = 8f;
    [SerializeField] float vidaBoss1 = 100f;

    public GameObject boss1;
    private Transform posicaoDoJogador;

    public Transform posicaoDoBoss1;

    private Vector2 target;

    public Material[] materialBoss;

    public Color danoCor;

    public float timeCorDano = 0.01f;


    
    


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
        target = new Vector2(posicaoDoBoss1.position.x, posicaoDoBoss1. position.y);
        
        boss1.transform.Rotate(0, 90, 0);
        
    }

    void Update()
    {
         if(vidaBoss1 <= 0)
        {
            GameController.instance.SetScore(100);
            SpawnEnemy.boss1NaCena = false;
            SpawnEnemy.boss1JaMorreu = true;
            //GameController.instance.ShowWinTela();
            Destroy(gameObject);
        }
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

     IEnumerator DanoCor()
    {
        GetComponent<Renderer>().materials[0].color = danoCor;

        yield return new WaitForSeconds(timeCorDano);

        GetComponent<Renderer>().materials[0].color = materialBoss[0].color;
    }

    void NormalState()
    {
        Debug.Log("State normal");

        currentAttack += Time.fixedDeltaTime;

        if (posicaoDoBoss1.gameObject != null)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoBoss1.position, speed * Time.deltaTime);
        }

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            state = State.Attack1;
        }


        /*
        if (currentAttack > stateNormalDuration)
        {
            state = State.Attack1;
            currentAttack = 0f;
        }
        */
    }

    

    void Attack1State()
    {
        Debug.Log("State attack1");

        currentAttack += Time.fixedDeltaTime;

        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador.position, speedAttack * Time.deltaTime);
        }

        if (currentAttack > attack1Duration)
        {
            state = State.Normal;
            currentAttack = 0f;
        }

        //StartCoroutine("VoltarNormalState");

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do player");
            vidaBoss1 = vidaBoss1 - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do playerr");
            vidaBoss1 = vidaBoss1 - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do playerr");
            vidaBoss1 = vidaBoss1 - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            StartCoroutine(DanoCor());
            Debug.Log("Boss levou um tiro do player");
            vidaBoss1 = vidaBoss1 - 4;
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            StartCoroutine(DanoCor());
            Debug.Log("lBoss levou um tiro do player");
            vidaBoss1 = vidaBoss1 - 0.8f;
            
        }

    }
}
