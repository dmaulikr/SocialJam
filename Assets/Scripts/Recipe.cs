using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour {
    public int meat;
    public int crop;
    public int produce;
	public int money;
    public int prestigeValue;
    PlayerState playerState;
    public bool playerHasIngredients = false;
	public string name;

	public Text pMeat;
	public Text pCrop;
	public Text pProduce;

	// Use this for initialization
	void Start () {
        playerState = FindObjectOfType<PlayerState>();
		pMeat = GameObject.FindGameObjectWithTag ("pMeat").GetComponent<Text>();
		pCrop = GameObject.FindGameObjectWithTag ("pCrop").GetComponent<Text>();
		pProduce = GameObject.FindGameObjectWithTag ("pProduce").GetComponent<Text>();
	}
		
    public void CheckIfPlayerHasIngredients()
	{
		pMeat.text = playerState.GetResourceQuantity (PlayerState.ResourceType.MEAT) + " / " + meat + " MEAT";
		pCrop.text = playerState.GetResourceQuantity (PlayerState.ResourceType.CROP) + " / " + crop + " CROP";
		pProduce.text = playerState.GetResourceQuantity (PlayerState.ResourceType.CROP) + " / " + produce + "PRODUCE";

		if (playerState.GetResourceQuantity(PlayerState.ResourceType.MEAT) >= meat && 
			playerState.GetResourceQuantity(PlayerState.ResourceType.CROP) >= crop && 
			playerState.GetResourceQuantity(PlayerState.ResourceType.PRODUCE) >= produce)
        {
            playerHasIngredients = true;
        }
        else
        {
            playerHasIngredients = false;
        }
    }

    public void CookRecipe()
    {
        CheckIfPlayerHasIngredients();
		if (playerHasIngredients == true)
        {
			playerState.ModifyResourceQuantity(PlayerState.ResourceType.MEAT, -meat);
			playerState.ModifyResourceQuantity (PlayerState.ResourceType.CROP, -crop);
			playerState.ModifyResourceQuantity (PlayerState.ResourceType.PRODUCE, -produce);
			playerState.ModifyResourceQuantity (PlayerState.ResourceType.MONEY, +money);
			playerState.ModifyResourceQuantity (PlayerState.ResourceType.PRESTIGE, +prestigeValue);
        }
    }
}
		
