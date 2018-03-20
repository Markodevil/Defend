using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	public void LoadScene()
    {
        SceneManager.LoadScene("Main");
	}
	
}
