using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRandomizer : MonoBehaviour {

	// ========================================
	// Properties
	// ========================================

	//[Tooltip("Resource which uniquely spawn for this player")]
	//[SerializeField]
	private GridSquareState.TileState permittedResource;

	private GridSquareState[] gridSquares;

	[SerializeField]
	private int resourcesSpawned;

	// ========================================
	// Game loop
	// ========================================

	void Start () {
		gridSquares = GameObject.FindObjectsOfType<GridSquareState>();
		if (Random.value <= 0.5f) {
			permittedResource = GridSquareState.TileState.CROP;
		} else {
			permittedResource = GridSquareState.TileState.PRODUCE;
		}
	}

	void Update () {
			
	}

	// ========================================
	// Public accessors
	// ========================================

	// Call to get an array of all grid squares
	public GridSquareState[] GetGridSquares() {
		return gridSquares;
	}

	// Call during every cycle to allocate resources to random grid locations
	public void RandomizeGrid() { 
		// Random permitted resource
		for (int i = 0; i < resourcesSpawned; ++i) {
			GridSquareState randomSquare = GetRandomSquare(gridSquares);
			if (randomSquare.GetTileState() == GridSquareState.TileState.EMPTY) {
				randomSquare.SetTileState(permittedResource);
			}
		}

		// Random captured creatures
		GridSquareState[] gridTraps = GetGridTraps();
		for (int i = 0; i < gridTraps.Length; ++i) {
			GridSquareState randomSquare = GetRandomSquare(gridTraps);
			randomSquare.SetTileState(GridSquareState.TileState.MEAT);
		}
	}

	// ========================================
	// Internal functions
	// ========================================

	private GridSquareState GetRandomSquare(GridSquareState[] gridArray) {
		int index = Random.Range(0, gridSquares.Length);
		return gridSquares[index];
	}

	private GridSquareState[] GetGridTraps() {
		GridSquareState[] traps = new GridSquareState[gridSquares.Length];
		int index = 0;
		foreach (GridSquareState square in gridSquares) {
			if (square.GetTileState() == GridSquareState.TileState.TRAP) {
				traps[index++] = square;
			}
		}
		return traps;
	}
}
