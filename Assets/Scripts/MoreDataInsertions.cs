using UnityEngine;
using System.Collections;

public class MoreDataInsertions : MonoBehaviour
{

    public string inputUserName;
    public string inputPassword;
    public string inputEmail;

    string CreateUserURL = "localhost:8012/GourmetPartay/InsertUser.php";

    // Use this for initialization
    void Start()
    {
        CreateUser(20, "Collins");
    }

    // Update is called once per frame

    public void CreateUser(int id, string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", id);
        form.AddField("namePost", name);
        form.AddField("mPost", 0);
        form.AddField("gPost", 0);
        form.AddField("vPost", 0);
        form.AddField("pPost", 0);

        WWW www = new WWW(CreateUserURL, form);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) ;
    }
}