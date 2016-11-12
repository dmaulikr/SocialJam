using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Facebook.Unity;

public class PlayerController : MonoBehaviour {

	[Tooltip("Game object with GridRandomizer component attached")]
	[SerializeField]
	private GameObject randomizerObject;

	[Tooltip("Money required for each trap")]
	[SerializeField]
	private int trapCost;

	[Tooltip("Resouce amount received from pickup")]
	[SerializeField]
	private int resourceAmount;

	private GridRandomizer randomizer;
	private GridSquareState[] gridSquares;
	private PlayerState playerState;

	// ========================================
	// Game loop
	// ========================================

    void Start()
    {
    	randomizer = randomizerObject.GetComponent<GridRandomizer>();
		gridSquares = randomizer.GetGridSquares();
		playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
    }

	// ========================================
	// Public manipulators
	// ========================================

	public GridSquareState GetCurrentSquare() {		
		foreach(GridSquareState state in gridSquares) {
			if (state.ContainsObject(gameObject)) {
				return state;
			}
		}
		return null;
	}

	// Call to retrieve context-specific actions
	public void performAction() {
		GridSquareState currentState = GetCurrentSquare();
		switch(currentState.GetTileState()) {
			case GridSquareState.TileState.EMPTY:
				SetTrap();
				break;
			case GridSquareState.TileState.TRAP:
				RemoveTrap();
				break;
			case GridSquareState.TileState.MEAT:
				CollectResource(PlayerState.ResourceType.MEAT);
				break;
			case GridSquareState.TileState.CROP:
				CollectResource(PlayerState.ResourceType.CROP);
				break;
			case GridSquareState.TileState.PRODUCE:
				CollectResource(PlayerState.ResourceType.PRODUCE);
				break;
			default:	
				break;
		}
	}

	// ========================================
	// Internal functions
	// ========================================

	public void SetTrap() {
		if (playerState.GetResourceQuantity(PlayerState.ResourceType.MONEY) < trapCost) {
			Debug.Log("Not enough money!");
			// Do something here
		}
		GridSquareState currentState = GetCurrentSquare();
		currentState.SetTrap();
		playerState.ModifyResourceQuantity(PlayerState.ResourceType.MONEY, -trapCost);
	}

	public void RemoveTrap() {
		GridSquareState currentState = GetCurrentSquare();
		currentState.ResetTile();
		playerState.ModifyResourceQuantity(PlayerState.ResourceType.MONEY, trapCost);
	}

	public void CollectResource(PlayerState.ResourceType resource) {
		GridSquareState currentState = GetCurrentSquare();
		currentState.ResetTile();
		playerState.ModifyResourceQuantity(resource, resourceAmount);
	}
}
