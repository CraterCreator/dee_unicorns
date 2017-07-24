using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool showLog;
    public GameObject login, create;
    public string username, password, email;
    // Use this for initialization
    void Start()
    {
        showLog = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!showLog)
        {
            login.SetActive(false);
            create.SetActive(true);
        }
        else
        {
            login.SetActive(true);
            create.SetActive(false);
        }
    }

    public void Press()
    {
        showLog = !showLog;
    }

    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username,password,email));
    }

    IEnumerator CreateUser(string userName, string passWord, string eMail)
    {
        string createUserURL = "http://localhost/unicorns_dee/InsertUser.php";

        WWWForm userInfo = new WWWForm();
        userInfo.AddField("usernamePost", userName);
        userInfo.AddField("passwordPost", passWord);
        userInfo.AddField("emailPost", eMail);
        WWW www = new WWW(createUserURL, userInfo);

        yield return www;

        Debug.Log(www.text);

    }
}
