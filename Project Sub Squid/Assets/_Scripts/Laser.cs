using UnityEngine;
using System.Collections;
public class Laser : MonoBehaviour
{
    public Color corLaser = Color.green;
    public int DistanciaDoLaser = 100;
    public float LarguraInicial = 0.2f, LarguraFinal = 0.1f;
    public Material material;
    private GameObject luzColisao;
    private Vector3 posicLuz;
    private bool ligado;
    void Start()
    {
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = LarguraFinal * 2;
        luzColisao.GetComponent<Light>().color = corLaser;
        posicLuz = new Vector3(0, 0, LarguraFinal);
        //
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(material);
        lineRenderer.SetColors(corLaser, corLaser);
        lineRenderer.SetWidth(LarguraInicial, LarguraFinal);
        lineRenderer.SetVertexCount(2);
    }
    void Update()
    {
        if (ligado == true)
        {
            luzColisao.SetActive(true);
            Vector3 PontoFinalDoLaser = transform.position + transform.right * DistanciaDoLaser;
            RaycastHit PontoDeColisao;
            if (Physics.Raycast(transform.position, transform.right, out PontoDeColisao, DistanciaDoLaser))
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, PontoDeColisao.point);
                luzColisao.transform.position = (PontoDeColisao.point - posicLuz);
            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, PontoFinalDoLaser);
                luzColisao.transform.position = PontoFinalDoLaser;
            }
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
            luzColisao.SetActive(false);
        }
        if (Input.GetKeyDown("i"))
        {
            ligado = !ligado;
        }
       
    }
}