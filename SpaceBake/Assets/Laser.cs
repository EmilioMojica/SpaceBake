using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer ray;

    Color32 Orange = new Color(255, 89, 22);

    // Use this for initialization
	void Start ()
	{
	    ray = GetComponent<LineRenderer>();
	    ray.material.color = Color.red;
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

    public void LightBlue()
    {
        ray.material.color = Color.blue;
    }
    public void LightWhite()
    {
        ray.material.color = Color.white;
    }
    public void LightBlack()
    {
        ray.material.color = Color.black;
    }
    public void LightOrange()
    {
        ray.material.color = Orange;
    }
    public void LightRed()
    {
        ray.material.color = Color.red;
    }
}
