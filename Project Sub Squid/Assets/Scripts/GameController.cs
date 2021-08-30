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

    public void Sair()
    {
        Application.Quit();
    }
    

}
