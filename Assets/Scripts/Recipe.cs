using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {
    public int meat;
    public int grains;
    public int vegatables;
    public int prestigeValue;
    PlayerState playerState;
    public bool playerHasIngredients = false;
	public string name;

	// Use this for initialization
	void Start () {
        playerState = FindObjectOfType<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CheckIfPlayerHasIngredients()
    {
        if (playerState.meat >= meat && playerState.grains >= grains && playerState.vegatables >= vegatables)
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
            playerState.vegatables -= vegatables;
            playerState.grains -= grains;
            playerState.prestige += prestigeValue;
        }
    }
}
