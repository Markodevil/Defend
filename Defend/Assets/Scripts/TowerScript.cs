using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public int health;
    public GameObject canvasObject;
    public GameObject timerObject;
    public float highscore;
    public float playingtime;
    public Text highscoreText;

    public void TakeDamage(int damageToTake)
    {
        health = health - damageToTake;
    }

    // Use this for initialization
    void Start()
    {
        // Load Player Prefs
        highscore = PlayerPrefs.GetFloat("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            canvasObject.SetActive(true);
            timerObject.SetActive(false);

        }
        if (health <= 0)
        {
            if (Time.timeScale == 1)
            {
                CompareHighscore();
                Time.timeScale = 0;
            }
        }
        if (health >= 1)
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
        }

    }
    void CompareHighscore()
    {
        playingtime = (float)Math.Round(Time.timeSinceLevelLoad, 3);
        if (playingtime > highscore)
        {
            highscore = playingtime;
            highscoreText.text = highscore.ToString();
            
            //To do: Show New Highscore Popup
            
            //Save Player Prefs
            PlayerPrefs.SetFloat("Highscore", highscore);
            PlayerPrefs.Save();
        }
    }
}
