using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiroNew : MonoBehaviour
{
    public Transform bullet;
    public Transform bulletPw1;

    public Transform bulletPw2;

    public Transform bulletPw3;

    public Transform bulletPW4;

  

    //public GameObject shot;
    public Transform shotSpawn;
    
    public float fireRate;
	private float nextFire;

    public static bool tiroPadrao;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.J) && Time.time > nextFire && Nave.isDash == false && Gun.tiroExtra == false)
        {
            Tiro();
            tiroPadrao = true;
            StartCoroutine ("NoTiroPadrao");
        }



    }

    IEnumerator NoTiroPadrao()
    {
        yield return new WaitForSeconds (0.5f);
        tiroPadrao = false;
        
    }

    void Tiro()
    {
        if(Nave.noPowerUp)
        {
        nextFire = Time.time + fireRate;
        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        FindObjectOfType<Audio_menager>().Play("tiro");

        }

        if(Nave.powerUp1)
        {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPw1, shotSpawn.position, shotSpawn.rotation);
        FindObjectOfType<Audio_menager>().Play("tiroagua");

        }

        if(Nave.powerUp2)
        {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPw2, shotSpawn.position, shotSpawn.rotation);
        }

        if(Nave.powerUp3)
        {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPw3, shotSpawn.position, shotSpawn.rotation);
        }

        if (Nave.powerUp4)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPW4, shotSpawn.position, shotSpawn.rotation);
        }


    }

}

