using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Dano : MonoBehaviour
{

    public Material[] materialBoss;

    public Color danoCor;

    public float timeCorDano = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("BossDano levou um tiro do playerr");
            
        }

        if (other.gameObject.tag == "TiroDuplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("BossDano levou um tiro do playerr");
            
        }

        if (other.gameObject.tag == "TiroTriplo")
        {
            StartCoroutine(DanoCor());
            Debug.Log("BossDano levou um tiro do playerr");
        }

        if (other.gameObject.tag == "TiroPesado")
        {
            StartCoroutine(DanoCor());
            Debug.Log("BossDano levou um tiro do playerr");
           
            
        }

        if (other.gameObject.tag == "5Tiros")
        {
            StartCoroutine(DanoCor());
            Debug.Log("BossDano levou um tiro do playerr");
    
            
        }

    }
}
