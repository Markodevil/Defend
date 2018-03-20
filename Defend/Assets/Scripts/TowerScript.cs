using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour {
    public int health;
    public GameObject canvasObject;
    public GameObject timerObject;

    public void TakeDamage(int damageToTake)
    {
        health = health - damageToTake;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            canvasObject.SetActive(true);
            timerObject.SetActive(false);
        }
    }
}
