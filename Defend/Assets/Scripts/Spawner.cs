﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;

    public float spawnTimeMin;
    public float spawnTimeMax;
    public float spawnTimeMin_Smallest;
    public float spawnTimeMax_Smallest;
    public float spawnTimeReducerAmount = 0.1f;

    public int startWait;
    public bool stop;

    public float spawnDistance = 15f;


    int randEnemy;
    
    
	void Start ()
    {
        StartCoroutine(waitSpawner());
        InvokeRepeating("ReduceSpawnTime", 5f, 2f);
    }
	
	
	void Update ()
    {
        spawnWait = Random.Range(spawnTimeMin, spawnTimeMax);
	}

    
    void ReduceSpawnTime()
    {
        spawnTimeMin = Mathf.Max(spawnTimeMin - spawnTimeReducerAmount, spawnTimeMin_Smallest);
        spawnTimeMax = Mathf.Max(spawnTimeMax - spawnTimeReducerAmount, spawnTimeMax_Smallest);
    }


    


    
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, 2);

            // old way of spawning between +/- 15 on X and Z
            //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            // choose a point at a random angle on a circle, at a fixed distance from the player

            // get a random direction (360°) in radians
            float angle = Random.Range(0.0f, Mathf.PI * 2);
            // create a vector to that angle with a length of 1
            Vector3 V = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            // scale it to the desired distance away to spawn
            V *= spawnDistance;

            // spawn creature
            Vector3 spawnPosition = transform.position + V;

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
    


}

