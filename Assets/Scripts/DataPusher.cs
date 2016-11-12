using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPusher : MonoBehaviour {
    string CreateUserURL = "localhost:8012/GourmetPartay/characterpropertiesPUSH.php";
    // Use this for initialization
    void Start () {
        CreateUser(767665, "Collins");
    }

    public void CreateUser(int fb_id, string p_name)
    {
        WWWForm form = new WWWForm();
        form.AddField("fbpost", fb_id);
        form.AddField("pnpost", p_name);
        form.AddField("mcpost", 0);
        form.AddField("gcpost", 0);
        form.AddField("vcpost", 0);
        form.AddField("pcpost", 0);
        WWW www = new WWW(CreateUserURL, form);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
