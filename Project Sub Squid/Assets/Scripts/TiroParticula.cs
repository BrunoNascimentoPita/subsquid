using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroParticula : MonoBehaviour
{

    public float speedTiro;

    private ParticleSystem tiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speedTiro * Time.deltaTime;
        Destroy(this.gameObject, 5.0f);
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0.1f);
            Debug.Log("Tiro inimigo acertou");
        }
    }
}
