using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MarketManager : MonoBehaviour {
	public ArrayList items;
	public ArrayList prices;
	public ArrayList inventory;
	private GameObject BuyCanvas;
	private GameObject SellCanvas;

	// Use this for initialization
	void Start () {
		BuyCanvas = GameObject.FindGameObjectWithTag ("BuyCanvas");
		SellCanvas = GameObject.FindGameObjectWithTag ("SellCanvas");
		items = new ArrayList ();
		prices = new ArrayList ();
		inventory = new ArrayList ();
		items.Add("Meat 20");
		items.Add("Vegi 100");
		items.Add("Grain 50");
		prices.Add("Grains 50");
		prices.Add("Meat 50");
		prices.Add("Vegi 50");
		inventory.Add("Meat 50");
		inventory.Add("Vegi 50");
		inventory.Add("Grains 50");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BuyPushed(){
		// when press buy from market, show the page with available item
		// 10 items each page, contain item1, price1.....
		int ind = 0;
		string item = "Item";
		string price = "Price";
		Transform priceTransform;
		Transform itemTransform;
		Text priceText;
		Text itemText;
		for (ind = 0; ind < items.Count; ind++) {
			itemTransform = BuyCanvas.transform.Find ("Text" + ind + "/" + item + ind);
			priceTransform = BuyCanvas.transform.Find ("Text" + ind + "/" + price + ind);
			itemText = itemTransform.GetComponent<Text> ();
			priceText = priceTransform.GetComponent<Text> ();
			itemText.text = (string)items[ind];
			priceText.text = (string)prices [ind];
		}
	}

	void SellPushed(){
		// when press sell from market, show the page with inventory
		int ind = 0;
		string item = "Item";
		Transform itemTransform;
		Text itemText;
		for (ind = 0; ind < inventory.Count; ind++) {
			itemTransform = SellCanvas.transform.Find ("Text" + ind + "/" + item + ind);
			itemText = itemTransform.GetComponent<Text> ();
			itemText.text = (string)inventory[ind];
		}
	}

	void BuyItem(){
		// when confirm buying, add to inventory
		string name = EventSystem.current.currentSelectedGameObject.name;
		int ind = name [-1];
		inventory [inventory.Count] = (string)items [ind];
		items.RemoveAt (ind);
	}

	void SellItem(){
		// invoke the selling interface
	}

	void SellCallBack(){
		// when confirm selling, update the database
	}

	void BuyCallBack(){
		// update the database after buying
	}
}
