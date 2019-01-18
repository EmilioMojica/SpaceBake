using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCanvasController : MonoBehaviour
{
    private int RecipeNumber; 

	// Use this for initialization
	void Start ()
    {
        RecipeNumber = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (RecipeNumber)
        {
            case 5:
                Recipe4();
                break;
            case 4:
                Recipe3();
                break;
            case 3:
                Recipe2();
                break;
            case 2:
                Recipe1();
                break;
            case 1:
                DefaultCanvas();
                break;
            default:
                DefaultCanvas();
                break;
        }
    }


    private void DefaultCanvas()
    {

    }

    private void Recipe1()
    {

    }

    private void Recipe2()
    {

    }

    private void Recipe3()
    {

    }

    private void Recipe4()
    {

    }
}
