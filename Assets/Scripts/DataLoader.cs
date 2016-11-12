using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {
    public string[] items;
    public string inputPlayerName;
	// Use this for initialization
	void Start () {
        //PullValues();
        CreateUser(67, "trash");
	}
    //data should be the entire string of a row of the DB
    //index should be the column name in the db you want to parse
    //"facebook_id:" or "player_name:" for example
    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

    public IEnumerator PullValues()
    {
        WWW itemsData = new WWW("http://localhost:8012/GourmetPartay/characterpropertiesPULL.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        //print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[1], "facebook_id:"));
    }
	
    public void CreateUser(int fb_id, string p_name)
    {
        WWWForm form = new WWWForm();
        //form.AddField("FB_POST", 010101010);
        form.AddField("PN_POST", "MyTest");
        form.AddField("MC_POST", 0);
        form.AddField("GC_POST", 0);
        form.AddField("VC_POST", 0);
        form.AddField("PC_POST", 0);
        WWW www = new WWW("http://localhost:8012/GourmetPartay/characterpropertiesPUSH.php", form.data);
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CreateUser(676767676, inputPlayerName);
        //}
	}
}
