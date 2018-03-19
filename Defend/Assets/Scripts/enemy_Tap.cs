using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tap : MonoBehaviour{

    public int damage;
    public float speed;
    private Transform target;
    private GameObject tower;
    private GameObject ObstacleSpawner;
    // Use this for initialization
    void Start()
    {
        ObstacleSpawner = GameObject.FindGameObjectWithTag("Spawner");
        //When they spawn it will look at the player
        tower = GameObject.FindGameObjectWithTag("Tower");
        Destroy(this.gameObject, 20f);
        transform.LookAt(tower.transform);
    }


    // Update is called once per frame
    void Update()
    {
        //will make it constantly move forward
        float step = speed * Time.deltaTime;
        transform.position += transform.forward * speed;
    }
    void OnCollisionEnter(Collision other)
    {
        //Every time a line created by swiping hits this obstacle, destroy this object
        if (other.gameObject.name == "Line")
        {
            //Destroy self
            Destroy(gameObject);
        }


        if (other.gameObject.tag == "Tower")
        {
            other.gameObject.GetComponent<TowerScript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }


    }
}