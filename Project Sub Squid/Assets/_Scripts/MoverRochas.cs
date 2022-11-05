using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRochas : MonoBehaviour
{
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverRochasM();
        VoltarRochasParaPosicao();
    }
    void MoverRochasM()
    {
        transform.position += new Vector3(-0.1f * velocidade * Time.deltaTime,0, 0);
    }

    void VoltarRochasParaPosicao()
    {
        if(transform.position.x <= -30f)
        {
            transform.position = new Vector3(30.2f,transform.position.y, transform.position.z);
        }
    }
}
