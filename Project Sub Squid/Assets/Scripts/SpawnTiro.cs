using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiro : MonoBehaviour
{

    public Transform bullet;
    public Transform bullet2;

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
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            Tiro1();
        }

        if(Input.GetKeyDown(KeyCode.K) && Time.time > nextFire)
        {
            Tiro2();
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
        
}
