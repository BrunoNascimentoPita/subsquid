using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : MonoBehaviour
{

    public float moveSpeed = 5;

    public float vidaEnemyGroup = 5;
    public float danoEnemyGroup = 2;

    //public Rigidbody enemyG;

    // Start is called before the first frame update
    void Start()
    {
        //enemyG = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        if(vidaEnemyGroup <= 0)
        {
            GameController.instance.SetScore(10);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;

        if(pos.x < -50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            Debug.Log("levou um tiro do player");
            vidaEnemyGroup = vidaEnemyGroup - 3;
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            Debug.Log("levou um tiro do player");
            vidaEnemyGroup = vidaEnemyGroup - 2;
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            Debug.Log("levou um tiro do player");
            vidaEnemyGroup = vidaEnemyGroup - 1;
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            Debug.Log("levou um tiro do Inimigo");
            vidaEnemyGroup = vidaEnemyGroup - 5;
            
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("chocou com o player");
            Destroy(this.gameObject, 0.1f);
        }

    }
}
