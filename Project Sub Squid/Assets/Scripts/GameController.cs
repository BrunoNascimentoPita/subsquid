using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject winTela;
    public GameObject pauseTela;
    public GameObject volumeSlider;

    public Text scoreText;
    private int score;

    // chamar boss

    public static int contadorEnemy;

    public static GameController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                //pauseTela.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                //pauseTela.SetActive(true);
                Time.timeScale = 1;
            }

        }
        */

        Debug.Log("Inimigos mortos" + contadorEnemy);

    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        Time.timeScale = 1;
    }

    public void ShowWinTela()
    {
        winTela.SetActive(true);
    }

    public void ShowPauseTela()
    {
        
        pauseTela.SetActive(true);
        //volumeSlider.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseTela.SetActive(false);
        //volumeSlider.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("_MenuInicial");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void ContadorDeinimigos()
    {
        contadorEnemy += 1;
    }
    

}
