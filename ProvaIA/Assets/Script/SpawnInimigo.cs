using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    public GameObject inimigo
        ;
    public float tempoSpawn;
    public Transform[] pontosdeSpawn;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartSpawn", tempoSpawn, tempoSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartSpawn()
    {
        int PontosSpawnIndex = Random.Range(0, pontosdeSpawn.Length);
        Instantiate(inimigo, pontosdeSpawn[PontosSpawnIndex].position, Quaternion.identity);

    }





}