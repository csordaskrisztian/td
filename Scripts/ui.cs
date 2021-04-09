using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public Text base_hp;
    public Text buildp;
    public GameObject pause;
    public GameObject cbutton;
    public GameObject pbutton;
    public GameObject rbutton;
    public GameObject qbutton;
    public GameObject pauseBackgroung;
    public GameObject nextlevelbutton;
    public GameObject loseText;
    public GameObject winText;
    public int maxlvl;

    private void Start()
    {
        rbutton.SetActive(false);
        qbutton.SetActive(false);
        game.gameover = false;
        Time.timeScale = 1;

    }
    void Update()
    {
        base_hp.text = "Base HP: " + Convert.ToString(game.hp);
        buildp.text = "Build Points: " + Convert.ToString(spawner.buildPoints);

        if (game.gameover == true)
        {
            Time.timeScale = 0;
            game.gameIsPaused = true;
            rbutton.SetActive(true);
            qbutton.SetActive(true);
            loseText.SetActive(true);
            pauseBackgroung.SetActive(true);
            pbutton.SetActive(false);


        }
        if (game.gameWon == true)
        {
            Time.timeScale = 0;
            game.gameIsPaused = true;
            qbutton.SetActive(true);
            winText.SetActive(true);
            pauseBackgroung.SetActive(true);
            pbutton.SetActive(false);

            int scene = SceneManager.GetActiveScene().buildIndex;
            if (scene < maxlvl)
            {
                nextlevelbutton.SetActive(true);

                if (PlayerPrefs.GetInt("currentlvl") < scene + 1)
                {
                    PlayerPrefs.SetInt("currentlvl", scene + 1);
                }
            }
            
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        cbutton.SetActive(true);
        pbutton.SetActive(false);
        pauseBackgroung.SetActive(true);

        game.gameIsPaused = true;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        cbutton.SetActive(false);
        pbutton.SetActive(true);
        pauseBackgroung.SetActive(false);

        game.gameIsPaused = false;
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game.hp = 10;

    }
    
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Nextlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
