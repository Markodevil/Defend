﻿using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {


	Vector3 previousTouchPoint;

	private GameObject fingerObject;
	private LineRenderer lineRenderer;
	private TrailRenderer trailRenderer;
	private int i = 0;

	private SphereCollider ballCollider;

    public bool tappingNow = false;
    public bool swipingNow = false;

    private Vector3 mouseDownPosition;
    private Vector3 touchPos;
    public float distanceForSwipe = 2f;


    // Use this for initialization
    void Start () {

		//Initialise the trailRenderer particles
		fingerObject = new GameObject("Line");
		fingerObject.AddComponent<TrailRenderer> ();
        fingerObject.GetComponent<TrailRenderer>().material = new Material(Shader.Find("Standard"));
        fingerObject.GetComponent<TrailRenderer> ().material.SetColor ("_Color", Color.red);
		fingerObject.GetComponent<TrailRenderer> ().startWidth = 0.5f;
		fingerObject.GetComponent<TrailRenderer> ().endWidth = 0.3f;
		fingerObject.GetComponent<TrailRenderer> ().time = 0.2f;
		fingerObject.GetComponent<TrailRenderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		fingerObject.GetComponent<TrailRenderer> ().receiveShadows = false;



		// add collider 
		BoxCollider bc = fingerObject.AddComponent<BoxCollider>();
		bc.size = new Vector3(1.0f, 1.0f, 1.0f);


	}

	// Update is called once per frame
	void Update () {

        // what is the mouse doing
        //Debug.Log("Tap: " + tappingNow + "   SWIPE: " + swipingNow);

		//You can simulate touch with the mouse by using the commented out code here. Use this for PC testing. Works on device as well
		//OnMouseDown

		if (Input.GetMouseButtonDown (0)) {
            // record mouse down position on the screen
            mouseDownPosition = Input.mousePosition;

            tappingNow = true;
            swipingNow = false;
        } 


		//OnMouseHold
		else if (Input.GetMouseButton (0)) {
			fingerObject.GetComponent<TrailRenderer> ().enabled = true;
			//raycast from screen to Ground in scene, if it hits it, set the fingerObject postiion
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Ground")
			{
				fingerObject.transform.position = hit.point - new Vector3 (0f, 2.1f, 0f);

			}


            // if player moves finger a lot, turn TAP into a SWIPE
            touchPos = Input.mousePosition;
            if (Vector3.Distance(mouseDownPosition, touchPos) > distanceForSwipe)
            {
                tappingNow = false;
                swipingNow = true;
            }



        } 

		//OnMouseUp
		else if (Input.GetMouseButtonUp (0)) {

			//move fingerObject out the way when your not touching the screen
			fingerObject.GetComponent<TrailRenderer>().enabled = false;
			fingerObject.transform.position = new Vector3 (-500.0f, -100.0f, -500.0f);

            tappingNow = false;
            swipingNow = false;

            // compare mouse up position to the mouse down position
            // if mouse was released within a small range from mouse down, then this was tap

		}



		//This is the code for touch inputs on the device. Won't work on PC. If testing on PC use the code above, for device the code above also works, but the below code allows for multitouch. 
        /*
		//for each touch (multitouch)
		for (var j = 0; j < Input.touchCount; ++j)
		{
			Touch touch = Input.GetTouch(j);
			//if its the first finger (touch)
			if (j == 0)
			{

				switch (touch.phase)
				{
				// When you finger touches
				case TouchPhase.Began:

					break;
					// When you finger stays
				case TouchPhase.Stationary:

					break;
					// When you finger moves
				case TouchPhase.Moved:
					fingerObject.GetComponent<TrailRenderer> ().enabled = true;
					//raycast from screen to Ground in scene, if it hits it, set the fingerObject postiion
					Ray ray = Camera.main.ScreenPointToRay( touch.position );
					RaycastHit hit;

					if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Ground")
					{
						fingerObject.transform.position = hit.point;

					}


					break;
					// When you finger lifts
				case TouchPhase.Ended:

					//move fingerObject out the way when your not touching the screen
					fingerObject.GetComponent<TrailRenderer>().enabled = false;
					fingerObject.transform.position = new Vector3 (-500.0f, -100.0f, -500.0f);

					break;
				}
			}
		}
        */

	}
}