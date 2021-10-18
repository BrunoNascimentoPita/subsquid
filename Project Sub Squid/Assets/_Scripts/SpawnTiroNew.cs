using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    // tiros PW

    public static int qTiros;
    public TextMeshProUGUI qTirosText;

    
    // Start is called before the first frame update
    void Start()
    {
        qTiros = 0;
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

        if(Input.GetKey(KeyCode.L) && Time.time > nextFire && Nave.isDash == false && Gun.tiroExtra == false && qTiros >= 1)
        {
            TiroPW();
            tiroPadrao = true;
            StartCoroutine ("NoTiroPadrao");
            qTiros = qTiros - 1;
        }


        qTirosText.text = qTiros.ToString();

        



    }

    IEnumerator NoTiroPadrao()
    {
        yield return new WaitForSeconds (0.5f);
        tiroPadrao = false;
        
    }

    void Tiro()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        FindObjectOfType<Audio_menager>().Play("tiro");

        /*
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
        */


    }

    void TiroPW()
    {
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
        FindObjectOfType<Audio_menager>().Play("tiroDuplo");
        }

        if(Nave.powerUp3)
        {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPw3, shotSpawn.position, shotSpawn.rotation);
        FindObjectOfType<Audio_menager>().Play("tiroTriplo");
        }

        if (Nave.powerUp4)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPW4, shotSpawn.position, shotSpawn.rotation);
            FindObjectOfType<Audio_menager>().Play("tiroPesado");
        }


    }

}

