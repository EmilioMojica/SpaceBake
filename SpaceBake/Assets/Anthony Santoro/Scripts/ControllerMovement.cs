﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour {

    public GameObject isHeld, isTargetted;
    public GameObject Hydrogen, Nitrogen, Oxygen, Carbon/*, NCHydrogen, NCNitrogen, NCOxygen, NCCarbon*/;
    public GameObject selectPosition;

    [SerializeField] private GameObject laserobject;
    private Laser laser;

    public Material hydrogenMat, nitrogenMat, carbonMat, oxygenMat, emptyAtom;

    public GameObject controller;

    public GameObject[] defaultSkin;
    public int skinLength;

    private int skinCheck;

    private RecipeCanvasController canvasController;

	// Use this for initialization
	void Start () {
        canvasController = GetComponent<RecipeCanvasController>();

        laser = laserobject.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) //(OVRInput.Button)//Input.GetMouseButtonDown(0))//OVRInput.GetDown(OVRInput.Button.One))
        {
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                if (hit.transform.name == "Hydrogen Sphere")
                {
                    isHeld = (GameObject)Instantiate(Hydrogen, selectPosition.transform.position, Quaternion.identity);
                    laser.LightBlue();
                }
                
                if (hit.transform.name == "Nitrogen Sphere")
                {
                    isHeld = (GameObject)Instantiate(Nitrogen, selectPosition.transform.position, Quaternion.identity);
                    laser.LightOrange();
                }

                if(hit.transform.name == "Oxygen Sphere")
                {
                    isHeld = (GameObject)Instantiate(Oxygen, selectPosition.transform.position, Quaternion.identity);
                    laser.LightWhite();
                }

                if(hit.transform.name == "Carbon Sphere")
                {
                    isHeld = (GameObject)Instantiate(Carbon, selectPosition.transform.position, Quaternion.identity);
                    laser.LightBlack();
                }             
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            laser.LightRed();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) //(Input.GetMouseButtonUp(0))//OVRInput.GetUp(OVRInput.Button.One))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 100.0f))
            {
                Debug.Log("RIP MY HEAD");

                if (isHeld.gameObject.name.Contains("Hydrogen") && hit.transform.name == ("Hydrogen Atom"))
                {
                    isTargetted = (GameObject)hit.transform.gameObject;
                    isTargetted.GetComponent<Renderer>().material = hydrogenMat;
                    Debug.Log("Hydrogen Molecule Completed");
                    Destroy(isHeld);
                }
                else if (isHeld.gameObject.name.Contains("Nitrogen") && hit.transform.name == ("Nitrogen Atom"))
                {
                    isTargetted = (GameObject)hit.transform.gameObject;
                    isTargetted.GetComponent<Renderer>().material = nitrogenMat;
                    Debug.Log("Nitrogen Molecule Completed");
                    Destroy(isHeld);
                }
                else if (isHeld.gameObject.name.Contains("Oxygen") && hit.transform.name == ("Oxygen Atom"))
                {
                    isTargetted = (GameObject)hit.transform.gameObject;
                    isTargetted.GetComponent<Renderer>().material = oxygenMat;
                    Debug.Log("Nitrogen Molecule Completed");
                    Destroy(isHeld);
                }
                else if (isHeld.gameObject.name.Contains("Carbon") && hit.transform.name == ("Carbon Atom"))
                {
                    isTargetted = (GameObject)hit.transform.gameObject;
                    isTargetted.GetComponent<Renderer>().material = carbonMat;
                    Debug.Log("Nitrogen Molecule Completed");
                    Destroy(isHeld);
                }
                else
                {
                    Destroy(isHeld);
                }   

            }
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) //(OVRInput.Button)//Input.GetMouseButtonDown(0))//OVRInput.GetDown(OVRInput.Button.One))
        {
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                if (hit.transform.name == "Back Button")
                {
                    canvasController.Down();
                }

                if (hit.transform.name == "Forward Button")
                {
                    canvasController.Up();
                }
            }
        }
    }
}
