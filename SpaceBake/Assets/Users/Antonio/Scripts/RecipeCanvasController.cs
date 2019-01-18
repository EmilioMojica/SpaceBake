using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCanvasController : MonoBehaviour
{
    public GameObject defaultRecipeCanvas; 
    public GameObject recipeCanvas1;
    public GameObject recipeCanvas2;
    public GameObject recipeCanvas3;
    public GameObject recipeCanvas4; 
    private int RecipeNumber; 

	// Use this for initialization
	void Start ()
    {
        RecipeNumber = 1;
        TurnOffCanvases();
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

    private void TurnOffCanvases()
    {
        defaultRecipeCanvas.SetActive(false);
        recipeCanvas1.SetActive(false);
        recipeCanvas2.SetActive(false);
        recipeCanvas3.SetActive(false);
        recipeCanvas4.SetActive(false);
    }

    private void DefaultCanvas()
    {
        defaultRecipeCanvas.SetActive(true);
        recipeCanvas1.SetActive(false);
        recipeCanvas2.SetActive(false);
        recipeCanvas3.SetActive(false);
        recipeCanvas4.SetActive(false);
    }

    private void Recipe1()
    {
        defaultRecipeCanvas.SetActive(false);
        recipeCanvas1.SetActive(true);
        recipeCanvas2.SetActive(false);
        recipeCanvas3.SetActive(false);
        recipeCanvas4.SetActive(false);
    }

    private void Recipe2()
    {
        defaultRecipeCanvas.SetActive(false);
        recipeCanvas1.SetActive(false);
        recipeCanvas2.SetActive(true);
        recipeCanvas3.SetActive(false);
        recipeCanvas4.SetActive(false);
    }

    private void Recipe3()
    {
        defaultRecipeCanvas.SetActive(false);
        recipeCanvas1.SetActive(false);
        recipeCanvas2.SetActive(false);
        recipeCanvas3.SetActive(true);
        recipeCanvas4.SetActive(false);
    }

    private void Recipe4()
    {
        defaultRecipeCanvas.SetActive(false);
        recipeCanvas1.SetActive(false);
        recipeCanvas2.SetActive(false);
        recipeCanvas3.SetActive(false);
        recipeCanvas4.SetActive(true);
    }

    public void Up()
    {
        if (RecipeNumber >= 5)
        {
            RecipeNumber = 1;
        }

        else
        {
            RecipeNumber++;
        } 
    }

    public void Down()
    {
        if (RecipeNumber <= 1)
        {
            RecipeNumber = 5;
        }

        else
        {
            RecipeNumber--;
        }
    }
}
