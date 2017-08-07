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
    public bool accForgot;
    public GameObject login, create, forgot, inputCode, resetPassword;
    public string username, password, email, recoveryCode;
    public InputField Username, Email, Password, forgotEmail, RecoveryCode, NPass, ConfirmNPass;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (accForgot)
        {
            if (forgotEmail.text != email)
            {
                email = forgotEmail.text;
            }
        }

        if (!accForgot)
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

        accForgot = true;
    }

    public void InputCode()
    {
        if (RecoveryCode.text == recoveryCode)
        {
            resetPassword.SetActive(true);
            inputCode.SetActive(false);
        }
    }

    public void ResetPassword()
    {
        if (NPass.text == ConfirmNPass.text)
        {
            StartCoroutine(UpdatePassword(email, NPass.text));
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void CreateAccountButton()
    {
        StartCoroutine(CreateUser(username, password, email));
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

    IEnumerator Login(string username, string password)
    {
        string loginURL = "localhost/unicorns_dee/Login.php";
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("usernamePost", username);
        loginForm.AddField("passwordPost", password);
        WWW www = new WWW(loginURL, loginForm);
        yield return www;

        Debug.Log(www.text);
        if (www.text == "Login Success")
        {
            // Action
        }
    }

    IEnumerator GetUser(string eMail)
    {
        string getUserName = "localhost/unicorns_dee/CheckUser.php";
        WWWForm getUserForm = new WWWForm();
        getUserForm.AddField("emailPost", eMail);
        WWW www = new WWW(getUserName, getUserForm);
        yield return www;
        Debug.Log(www.text);
        if (www.text != "No User")
        {
            username = www.text;
            SendEmail();
        }

    }


    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(email);
        mail.Subject = "Password Reset";
        recoveryCode = CodeGenerator.CodeGenerate(6);
        mail.Body = "Hello " + username + "\nreset using the code:" + recoveryCode;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 25;
        smtpServer.Credentials = new System.Net.NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };
        smtpServer.Send(mail);

        Debug.Log("Success");

        forgot.SetActive(false);
        inputCode.SetActive(true);
    }

    IEnumerator UpdatePassword(string eMail, string passWord)
    {
        string PasswordURL = "localhost/unicorns_dee/UpdatePassword.php";
        WWWForm passwordForm = new WWWForm();
        passwordForm.AddField("emailPost", eMail);
        passwordForm.AddField("passwordPost", passWord);
        WWW www = new WWW(PasswordURL, passwordForm);

        yield return www;
        Debug.Log(www.text);
        if (www.text != "error")
        {
            login.SetActive(true);
            resetPassword.SetActive(false);


            accForgot = false;
        }

    }

}
