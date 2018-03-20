using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public float Timer = 3;
    public Text timerText;
    public bool timerIsActive = true;

	// Use this for initialization
	void Start ()
    {
        timerText = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timerIsActive)
        {
            Timer -= Time.deltaTime;
            timerText.text = Timer.ToString("f0");
            if (Timer <= 0)
            {
                Timer = 0;
                timerIsActive = false;
            }
        }
	}
}
