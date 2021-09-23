using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLaser : MonoBehaviour
{
    public float tamanhoLaser;
    public LineRenderer LaserLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        LaserLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raioLaser = Physics2D.Raycast(transform.position, transform.right, tamanhoLaser);


        if (raioLaser == true)
        {
            LaserLineRenderer.SetPosition(1, transform.position);
            LaserLineRenderer.SetPosition(0, raioLaser.point);

        }
        else
        {
            Vector3 fimLaser = new Vector3(transform.position.y, transform.position.x + tamanhoLaser, 0);
            LaserLineRenderer.SetPosition(1, transform.position);
            LaserLineRenderer.SetPosition(0, fimLaser);


        }
    }
}
   
   



