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
    public string[] dbItems;
    private string playerID;
    private string playerName;
    private string howMuchPrestige;
    private string howMuchMeat;
    private string howMuchGrain;
    private string howMuchVeggie
    private string CreateUserURL = "localhost:8012/GourmetPartay/updatePlayerInfo.php";

    // Use this for initialization
    void Start () {
		BuyCanvas = GameObject.FindGameObjectWithTag ("BuyCanvas");
		SellCanvas = GameObject.FindGameObjectWithTag ("SellCanvas");
        PullValues();
        items = new ArrayList ();
		prices = new ArrayList ();
		inventory = new ArrayList ();
		items.Add("Meat 20");
		items.Add("Vegi 100");
		items.Add("Grain 50");
		prices.Add("Grains 50");
		prices.Add("Meat 50");
		prices.Add("Vegi 50");
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
        BuyCallBack();
	}


    public IEnumerator PullValues()
    {
        WWW itemsData = new WWW("localhost:8012/GourmetPartay/characterpropertiesPULL.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        dbItems = itemsDataString.Split(';');
        playerID = GetDataValue(dbItems[0], "facebook_id:");
        playerName = GetDataValue(dbItems[0], "player_name:");
        howMuchMeat = GetDataValue(dbItems[0], "meat_count:");
        inventory.Add("Meat " + howMuchMeat);
        howMuchGrain = GetDataValue(dbItems[0], "grain_count:");
        inventory.Add("Grain " + howMuchGrain);
        howMuchVeggie = GetDataValue(dbItems[0], "veggie_count:");
        inventory.Add("Veggie " + howMuchVeggie);
        howMuchPrestige = GetDataValue(dbItems[0], "prestige_count:");

    }

    public void UpdateUser(int id, string name, int count1, int count2, int count3, int count4)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("namePost", name);
        form.AddField("mPost", count1);
        form.AddField("gPost", count2);
        form.AddField("vPost", count3);
        form.AddField("pPost", count4);
        WWW www = new WWW(CreateUserURL, form);
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

    void SellItem(){
		// invoke the selling interface
	}

	void SellCallBack(){
		// when confirm selling, update the database
	}

	void BuyCallBack(){
        // update the database after buying
        UpdateUser(int.Parse(playerID), playerName, int.Parse(howMuchMeat), int.Parse(howMuchGrain), int.Parse(howMuchVeggie), int.Parse(howMuchPrestige));
	}
}
