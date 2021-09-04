using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiro : MonoBehaviour
{

    public Transform bullet;
    public Transform bullet2;

    public Transform bullet3;

    public Transform bulletPesado;

    public Transform bulletZigZag;

    //public GameObject shot;
	public Transform shotSpawn;
    
    public float fireRate;
	private float nextFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.J) && Time.time > nextFire)
        {
            Tiro1();
        }

        if(Input.GetKeyDown(KeyCode.K) && Time.time > nextFire)
        {
            Tiro2();
        }

        if(Input.GetKeyDown(KeyCode.L) && Time.time > nextFire)
        {
            Tiro3();
        }

        if(Input.GetKeyDown(KeyCode.I) && Time.time > nextFire)
        {
            TiroPesado();
        }

        if(Input.GetKeyDown(KeyCode.O) && Time.time > nextFire)
        {
            TiroZigZag();
        }


    }

    void Tiro1()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

    }

    void Tiro2()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet2, shotSpawn.position, shotSpawn.rotation);
    }

    void Tiro3()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet3, shotSpawn.position, shotSpawn.rotation);
    }

    void TiroPesado()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletPesado, shotSpawn.position, shotSpawn.rotation);
    }

    void TiroZigZag()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bulletZigZag, shotSpawn.position, shotSpawn.rotation);
    }

        
}
