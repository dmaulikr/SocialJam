using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {
    public string[] items;
	// Use this for initialization
	IEnumerator Start () {
        WWW itemsData = new WWW("http://localhost:8012/GourmetPartay/characterproperties.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        //print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[0], "facebook_id:"));
	}

    //data should be the entire string of a row of the DB
    //index should be the column name in the db you want to parse
    //"facebook_id:" or "player_name:" for example
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
