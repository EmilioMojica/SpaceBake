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
	    Transform rightHandAnchor; // Assign to the proper transform
	    Ray pointer = new Ray(ray.transform.position, ray.transform.forward);

	    ray.SetPosition(0, pointer.origin);
	    ray.SetPosition(1, pointer.origin + pointer.direction * 100f);

    }
}
