using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

public class GameManager : MonoBehaviour
{
    public bool showLog, accForgot;
    public GameObject login, create, forgot;
    public string username, password, email;
    public InputField Username, Email, Password, forgotEmail; 
    // Use this for initialization
    void Start()
    {
        showLog = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(accForgot)
        {
            if (forgotEmail.text != email)
            {
                email = forgotEmail.text;
            }
        }
     
        if (!showLog && !accForgot)
        {
            if (Username.text != username)
            {
                username = Username.text;
            }

            if (Password.text != password)
            {
                password = Password.text;
            }

            if (Email.text != email)
            {
                email = Email.text;
            }
        }
    }

    public void Press()
    {
        login.SetActive(false);
        create.SetActive(true);
    }
    public void Press2()
    {
        login.SetActive(false);
        forgot.SetActive(true);
    }

    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username,password,email));
    }

    IEnumerator CreateUser(string userName, string passWord, string eMail)
    {
        string createUserURL = "localhost/unicorns_dee/InsertUser.php";

        WWWForm userInfo = new WWWForm();
        userInfo.AddField("usernamePost", userName);
        userInfo.AddField("passwordPost", passWord);
        userInfo.AddField("emailPost", eMail);
        WWW www = new WWW(createUserURL, userInfo);

        yield return www;

        Debug.Log(www.text);

    }

    public void StartLogin()
    {
        StartCoroutine(Login(username, password));
    }

    public void ForgotAccount()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(email);
        mail.Subject = "Password Reset";
        mail.Body = "Hello User /n/n Someones gone and done a goof /n Reset password here...";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 25;
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors errors) { return true; };
        smtpServer.Send(mail);

        Debug.Log("Email Sent");
    }

    IEnumerator Login(string username, string password)
    {
        string loginURL = "localhost/unicorns_dee/Login.php";
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("usernamePost", username);
        loginForm.AddField("passwordPost", password);
        WWW www = new WWW(loginURL, loginForm);
        yield return www;

        Debug.Log(www.text);
        if(www.text == "Login Success")
        {
            // Action
        }
    }
}
