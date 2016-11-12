using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	// ========================================
	// Local variables
	// ========================================

	public enum ResourceType {
		PRESTIGE = 0,
		MONEY = 1,
		MEAT = 2,
		CROP = 3,
		PRODUCE = 4
	};

    private int prestige, money, meat, crop, produce;

	// ========================================
	// Game loop
	// ========================================

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ========================================
	// Public manipulators
	// ========================================

	// Use to add / subtract amount of a given resource
	public void ModifyResourceQuantity(ResourceType type, int quantity) {
		switch (type) {
			case ResourceType.PRESTIGE:
				prestige += quantity;
				break;
			case ResourceType.MONEY:
				money += quantity;
				break;
			case ResourceType.MEAT:
				meat += quantity;
				break;
			case ResourceType.CROP:
				crop += quantity;
				break;
			case ResourceType.PRODUCE:
				produce += quantity;
				break;
			default:
				Debug.Log("Invalid resource type");
				break;
		}
		ResourceSanityCheck();
	}

	public int GetResourceQuantity(ResourceType type) {
		switch (type) {
			case ResourceType.PRESTIGE:
				return prestige;
				break;
			case ResourceType.MONEY:
				return money;
				break;
			case ResourceType.MEAT:
				return meat;
				break;
			case ResourceType.CROP:
				return crop;
				break;
			case ResourceType.PRODUCE:
				return produce;
				break;
			default:
				Debug.Log("Invalid resource type");
				return 0;
				break;
		}
	}

	// ========================================
	// Internal functions
	// ========================================

	private void ResourceSanityCheck() {
		if (prestige < 0) {
			prestige = 0;
		}
		if (money < 0) {
			money = 0;
		}
	 	if (meat < 0) {
	 		meat = 0;
	 	}
	 	if (crop < 0) {
			crop = 0;
	 	}
	 	if (produce < 0) {
	 		produce = 0;
	 	}
	}
}
