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
        RaycastHit hit;
        ray.SetPosition(0, pointer.origin);

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            ray.SetPosition(1,hit.point);

        }

    }
}
