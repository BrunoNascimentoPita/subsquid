using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] enemy;
    int randowEnemy;
    public float tempoSpawn;
    public Transform[] pontosdeSpawnEnemy;

    // grupe enemy

    public GameObject[] enemyGroup;
    int randowEnemyG;
    public float tempoSpawnEG;
    public Transform pontosdeSpawnEG;

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

    // spawn Boss1Baleia
    public GameObject bossBaleia1;
    public Transform pontosdeSpawnBoss1;

    // spawn Boss2
    public GameObject boss2;
    public Transform pontosdeSpawnBoss2;

    public static bool boss1NaCena = false;

    public static bool boss1JaMorreu;
    public static bool boss2NaCena = false;

    public static bool boss2JaMorreu;


    // Start is called before the first frame update
    void Start()
    {
        boss1NaCena = false;
        boss2NaCena = false;
        boss1JaMorreu = false;
        boss2JaMorreu = false;
        StartCoroutine ("StartSpawn");
        StartCoroutine ("StartSpawnEG");
        StartCoroutine("StartSpawnES");
        InvokeRepeating("SpawnRandomPW", spawntime, spawndelay);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.contadorEnemy >= 5 && GameController.contadorEnemy <= 15)
        {
            tempoSpawn = 5.0f;
        }

        if (GameController.contadorEnemy >= 16 && GameController.contadorEnemy <= 29)
        {
            tempoSpawn = 2.5f;
        }

        if (GameController.contadorEnemy == 15 && !boss1NaCena && !boss1JaMorreu)
        {
            StartCoroutine ("ChamarBossBaleia");
        }

        if (GameController.contadorEnemy == 30 && !boss2NaCena && !boss2JaMorreu)
        {
            StartCoroutine ("ChamarBoss2");
        }
    }

    void ChamarSpawn()
    {
        //InvokeRepeating("StartSpawn", tempoSpawn, tempoSpawn);
    }

    IEnumerator ChamarBossBaleia()
    {
        boss1NaCena = true;
        yield return new WaitForSeconds (1.0f);
        Instantiate(bossBaleia1, pontosdeSpawnBoss1.position, Quaternion.identity);
    }

    IEnumerator ChamarBoss2()
    {
        boss2NaCena = true;
        yield return new WaitForSeconds (1.0f);
        Instantiate(boss2, pontosdeSpawnBoss2.position, Quaternion.identity);
    }

    IEnumerator StartSpawn()
    {
            yield return new WaitForSeconds (tempoSpawn);
            if (!boss1NaCena && !boss2NaCena && !boss2JaMorreu)
            {
                randowEnemy = Random.Range(0, enemy.Length);
                int PontosSpawnIndexEnemy = Random.Range(0, pontosdeSpawnEnemy.Length);
                Instantiate(enemy[randowEnemy], pontosdeSpawnEnemy[PontosSpawnIndexEnemy].position, Quaternion.identity);
                
            }
            StartCoroutine ("StartSpawn");

    }

    IEnumerator StartSpawnEG()
    {
            yield return new WaitForSeconds (tempoSpawnEG);
            if (!boss1NaCena && !boss2NaCena && !boss2JaMorreu)
            {
                randowEnemyG = Random.Range(0, enemyGroup.Length);
                
                Instantiate(enemyGroup[randowEnemyG], pontosdeSpawnEG.position, Quaternion.identity);
                
            }
            StartCoroutine ("StartSpawnEG");

    }

    IEnumerator StartSpawnES()
    {
        yield return new WaitForSeconds (tempoSpawnES);
        
        if (!boss1NaCena && !boss2NaCena && !boss2JaMorreu)
        {
            int PontosSpawnIndexES = Random.Range(0, pontosdeSpawnES.Length);
            Instantiate(enemySeguir, pontosdeSpawnES[PontosSpawnIndexES].position, Quaternion.identity);  
        }
        

        StartCoroutine ("StartSpawnES");
    }

    void SpawnRandomPW()
    { 
            randomPW = Random.Range(0 ,spawnPW.Length);
            int PontosSpawnIndexPW = Random.Range(0, pontosdeSpawnPW.Length);
            Instantiate(spawnPW[randomPW], pontosdeSpawnPW[PontosSpawnIndexPW].position, Quaternion.identity);
            //Instantiate(spawnPW[randomPW],transform.position, transform.rotation);

    }

}
