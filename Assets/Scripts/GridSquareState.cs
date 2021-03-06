﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquareState : MonoBehaviour {

	// ========================================
	// Properties
	// ========================================

	private new SpriteRenderer renderer;
	private BoxCollider2D tileBounds;

	[Tooltip("Image for empty tiles")]
	[SerializeField]
	private Sprite emptyTileSprite;

	[Tooltip("Image for tiles with traps placed")]
	[SerializeField]
	private Sprite trapTileSprite;

	[Tooltip("Image for tiles with dead enemy in trap")]
	[SerializeField]
	private Sprite meatTileSprite;

	[Tooltip("Image for tiles with crops placed")]
	[SerializeField]
	private Sprite cropTileSprite;

	[Tooltip("Image for tiles with produce placed")]
	[SerializeField]
	private Sprite produceTileSprite;

	// ========================================
	// State variables
	// ========================================

	public enum TileState { 
		EMPTY = 0, 
		TRAP = 1,
		MEAT = 2,
		CROP = 3,
		PRODUCE = 4
	};

	public TileState currentState;

	// ========================================
	// Game loop
	// ========================================

	// Initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		tileBounds = GetComponent<BoxCollider2D>();

		currentState = TileState.EMPTY;
	}

	// Rendering
	void LateUpdate () {
		SetTileSprites();
	}

	// ========================================
	// Public manipulators
	// ========================================

	public void ResetTile() {
		currentState = TileState.EMPTY;
	}

	public void SetTrap() {
		currentState = TileState.TRAP;
	}

	public void SetDead() {
		currentState = TileState.MEAT;
	}

	public void SetCrop() {
		currentState = TileState.CROP;
	}

	public bool ContainsObject(GameObject target) {
		// Sanity check
		if (!tileBounds) {
			Debug.Log("BoxCollider2D component missing; please attach to prefab");
			return false;
		}

		Vector3 targetPosition = target.transform.position;
		if (tileBounds.bounds.Contains(targetPosition)) {
			return true;
		} else {
			return false;
		}
	}

	public TileState GetTileState() {
		return currentState;
	}

	public void SetTileState(TileState state) {
		currentState = state;
	}

	// ========================================
	// Internal functions
	// ========================================

	private void SetTileSprites() {
		// Sanity check
		if(!renderer) {
			Debug.Log("Sprite Renderer component missing; please attach to prefab");
			return;
		}

		switch (currentState) {
			case TileState.EMPTY:
				renderer.sprite = emptyTileSprite;
				break;
			case TileState.TRAP:
				renderer.sprite = trapTileSprite;
				break;
			case TileState.MEAT:
				renderer.sprite = meatTileSprite;
				break;
			case TileState.CROP:
				renderer.sprite = cropTileSprite;
				break;
			case TileState.PRODUCE:
				renderer.sprite = produceTileSprite;
				break;
			default:
				renderer.sprite = emptyTileSprite;	
				break;
		}
	}

}