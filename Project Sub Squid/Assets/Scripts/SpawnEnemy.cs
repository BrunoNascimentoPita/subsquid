using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public float tempoSpawn;
    public Transform[] pontosdeSpawn;

    // Inimigo Seguir

    public GameObject enemySeguir;
    public float tempoSpawnES;
    public Transform[] pontosdeSpawnES;

    // spawn PowerUps

    public GameObject[] spawnPW;
    int randomPW;
    public float spawntime;
    public float spawndelay;

    public Transform[] pontosdeSpawnPW;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartSpawn", tempoSpawn, tempoSpawn);
        InvokeRepeating("StartSpawnES", tempoSpawnES, tempoSpawnES);
        InvokeRepeating("SpawnRandomPW", spawntime, spawndelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSpawn()
    {
          int PontosSpawnESIndex = Random.Range(0, pontosdeSpawnES.Length);
          Instantiate(enemySeguir, pontosdeSpawnES[PontosSpawnESIndex].position, Quaternion.identity);

    }

    void StartSpawnES()
    {
          int PontosSpawnIndex = Random.Range(0, pontosdeSpawn.Length);
          Instantiate(enemy, pontosdeSpawn[PontosSpawnIndex].position, Quaternion.identity);

    }

    void SpawnRandomPW()
    { 
            randomPW= Random.Range(0, spawnPW.Length);
            int PontosSpawnIndexPW = Random.Range(0, pontosdeSpawnPW.Length);
            Instantiate(spawnPW[randomPW], pontosdeSpawnPW[PontosSpawnIndexPW].position, Quaternion.identity);
            //Instantiate(spawnPW[randomPW],transform.position, transform.rotation);

    }

}
