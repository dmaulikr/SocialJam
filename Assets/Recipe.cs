using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    public int meat;
    public int plants;
    public int liquids;
    public int prestigeValue;
    PlayerState playerState;
    public bool playerHasIngredients = false;

	// Use this for initialization
	void Start () {
        playerState = FindObjectOfType<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void CheckIfPlayerHasIngredients()
    {
        if (playerState.meat >= meat && playerState.plants >= plants && playerState.liquids >= liquids)
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
        if (playerHasIngredients)
        {
            playerState.meat -= meat;
            playerState.plants -= plants;
            playerState.liquids -= liquids;
            playerState.prestige += prestigeValue;
        }
    }
}
