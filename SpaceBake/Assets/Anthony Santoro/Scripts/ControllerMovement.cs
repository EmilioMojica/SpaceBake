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
        skinLength = defaultSkin.Length;
        canvasController = GetComponent<RecipeCanvasController>();

        laser = laserobject.GetComponent<Laser>();

        //NCHydrogen.SetActive(false);
        //NCNitrogen.SetActive(false);
        //NCOxygen.SetActive(false);
        //NCCarbon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        skinLength = defaultSkin.Length;

        foreach (GameObject skin in defaultSkin)
        {
            if (skin.GetComponent<Renderer>().material != emptyAtom)
            {
                skinCheck++;
            }
        }

        if(skinCheck == skinLength)
        {
            if (skinLength == 2)
            {
                GameObject.Find("BarScreen").GetComponent<ResourceBars>().AddO2();
            }
            else if (skinLength == 3)
            {
                GameObject.Find("BarScreen").GetComponent<ResourceBars>().AddH2O();
            }
            else if (skinLength == 8)
            {
                GameObject.Find("BarScreen").GetComponent<ResourceBars>().AddC2H3NO2();
            }
            else if (skinLength == 9)
            {
                GameObject.Find("BarScreen").GetComponent<ResourceBars>().AddC2H5OH();
            }
            }

        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) //(OVRInput.Button)//Input.GetMouseButtonDown(0))//OVRInput.GetDown(OVRInput.Button.One))
        {
            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                if (hit.transform.name == "Hydrogen Sphere")
                {
                    isHeld = Hydrogen;
                    laser.LightBlue();
                    //NCHydrogen.SetActive(true);
                    //NCNitrogen.SetActive(false);
                    //NCOxygen.SetActive(false);
                    //NCCarbon.SetActive(false);
                }
                
                else if (hit.transform.name == "Nitrogen Sphere")
                {
                    isHeld = Nitrogen;
                    laser.LightOrange();

                    //NCHydrogen.SetActive(false);
                    //NCNitrogen.SetActive(true);
                    //NCOxygen.SetActive(false);
                    //NCCarbon.SetActive(false);
                }

                else if(hit.transform.name == "Oxygen Sphere")
                {
                    isHeld = Oxygen;
                    laser.LightWhite();

                    //NCHydrogen.SetActive(false);
                    //NCNitrogen.SetActive(false);
                    //NCOxygen.SetActive(true);
                    //NCCarbon.SetActive(false);
                }

                else if(hit.transform.name == "Carbon Sphere")
                {
                    isHeld = Carbon;
                    laser.LightBlack();

                    //NCHydrogen.SetActive(false);
                    //NCNitrogen.SetActive(false);
                    //NCOxygen.SetActive(false);
                    //NCCarbon.SetActive(true);
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
<<<<<<< HEAD
                    ResetAtoms();
=======
>>>>>>> parent of 562039b... Update ControllerMovement.cs
                }

                if (hit.transform.name == "Forward Button")
                {
                    canvasController.Up();
<<<<<<< HEAD
                    ResetAtoms();
                }
=======
                }  
>>>>>>> parent of 562039b... Update ControllerMovement.cs
            }
        }
    }
}
