using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRefresh : MonoBehaviour
{

    private float _timeToReset = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _timeToReset -= Time.deltaTime;

	    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
	    {
	        _timeToReset = 45;
	    }

        if (_timeToReset <= 0)
            SceneManager.LoadScene("SpaceShuttle");
    }
}
