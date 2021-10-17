using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 40;
    public float fireRate = 3f;
    public float weaponRange = 200f;
    public LineRenderer lineRenderer;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);
    private float nextFire;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(Shoot());
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);


            if (hitInfo)
            {
                lineRenderer.SetPosition(0, firePoint.position);
            }

     }            
            else
            {
            
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * weaponRange);
            }
        
  
    IEnumerator Shoot()
    {
          
     lineRenderer.enabled = true;
     yield return shotDuration; 
     lineRenderer.enabled = false;
    }
    

    }
}
