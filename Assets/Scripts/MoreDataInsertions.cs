using UnityEngine;
using System.Collections;

public class MoreDataInsertions : MonoBehaviour
{

    public string PlayerName;
    public int ID;
    public int MC;
    public int GC;
    public int VC;
    public int PC;

    string CreateUserURL = "localhost:8012/GourmetPartay/InsertUser.php";

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame

    public void CreateUser(int id, string name, int count1, int count2, int count3, int count4)
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) CreateUser(ID, PlayerName, MC, GC, VC, PC);
    }
}