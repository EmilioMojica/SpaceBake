using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRaycast : MonoBehaviour
{
    public GameObject HydrogenCrate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                if (HydrogenCrate != hit.collider.gameObject)
                {
                    HydrogenCrate = hit.transform.gameObject;
                    HydrogenCrate.SendMessage("HydrogenCrateOpen");
                    Debug.Log("On VR Raycast Enter");
                }
            }
        }
	}
}
