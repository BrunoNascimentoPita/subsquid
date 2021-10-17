using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLaser : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = 25f;
    public float weaponRange = 50;
    public float hitForce = 100;
    public Transform gunEnd;


    private WaitForSeconds shotDuration = new WaitForSeconds(0.8f);
    private LineRenderer laserLine;
    private float nextFire;
   
  



    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
      
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = (new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, transform.position += Vector3.right);

            if (!Physics.Raycast(rayOrigin,transform.position ,  out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                
                laserLine.SetPosition(1, rayOrigin + ( transform.position * weaponRange));
            }

        }
    }
    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;

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
