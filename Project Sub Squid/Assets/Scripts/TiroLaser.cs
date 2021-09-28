using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLaser : MonoBehaviour
{
   
    public float speedTiro = 10f;
   

    void Update()
    {
        transform.position += Vector3.right * speedTiro * Time.deltaTime;
        Destroy(this.gameObject, 5.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Enemy")
        {

            Destroy(this.gameObject, 0.1f);
        }

        if (other.gameObject.tag == "Boss1")
        {

            Destroy(this.gameObject, 0.1f);
        }

    }
}
