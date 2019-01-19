using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer ray;

    // Use this for initialization
	void Start ()
	{
	    ray = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    Ray pointer = new Ray(gameObject.transform.position, gameObject.transform.forward);

	    RaycastHit hit;

	    if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
	    {
	        //ray.positionCount = hit.distance;
            ray.SetPosition(0, pointer.origin);
	        ray.SetPosition(1, pointer.origin + pointer.direction * hit.distance); //pointer.direction);
	    }
	    else
	    {
	        ray.SetPosition(0, pointer.origin);
	        ray.SetPosition(1, pointer.origin + pointer.direction * 3); //pointer.direction);
	    }
	}
}
