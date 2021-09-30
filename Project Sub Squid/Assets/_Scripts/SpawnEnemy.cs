using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] enemy;
    int randowEnemy;
    public float tempoSpawn;
    public Transform[] pontosdeSpawnEnemy;

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
        StartCoroutine ("StartSpawn");
        InvokeRepeating("StartSpawnES", tempoSpawnES, tempoSpawnES);
        InvokeRepeating("SpawnRandomPW", spawntime, spawndelay);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.contadorEnemy >= 5 && GameController.contadorEnemy <= 15)
        {
            tempoSpawn = 5;
        }
    }

    void ChamarSpawn()
    {
        //InvokeRepeating("StartSpawn", tempoSpawn, tempoSpawn);
    }

    IEnumerator StartSpawn()
    {
            yield return new WaitForSeconds (tempoSpawn);
            randowEnemy = Random.Range(0, enemy.Length);
            int PontosSpawnIndexEnemy = Random.Range(0, pontosdeSpawnEnemy.Length);
            Instantiate(enemy[randowEnemy], pontosdeSpawnEnemy[PontosSpawnIndexEnemy].position, Quaternion.identity);
            StartCoroutine ("StartSpawn");

    }

    void StartSpawnES()
    {
          int PontosSpawnIndexES = Random.Range(0, pontosdeSpawnES.Length);
          Instantiate(enemySeguir, pontosdeSpawnES[PontosSpawnIndexES].position, Quaternion.identity);

    }

    void SpawnRandomPW()
    { 
            randomPW = Random.Range(0 ,spawnPW.Length);
            int PontosSpawnIndexPW = Random.Range(0, pontosdeSpawnPW.Length);
            Instantiate(spawnPW[randomPW], pontosdeSpawnPW[PontosSpawnIndexPW].position, Quaternion.identity);
            //Instantiate(spawnPW[randomPW],transform.position, transform.rotation);

    }

}
