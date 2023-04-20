using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private GameObject loginPanel;

    [SerializeField]
    private GameObject registrationPanel;

    //Login variables
    [Space]
    [Header("Login")]
    [SerializeField]
    private InputField emailLoginField;
    [SerializeField]
    private InputField passwordLoginField;
    [SerializeField]
    private Text warningLoginText;
    [SerializeField]
    private Text confirmLoginText;

    //Register variables
    [Space]
    [Header("Register")]
    [SerializeField]
    private InputField UsernameRegisterField;
    [SerializeField]
    private InputField emailRegisterField;
    [SerializeField]
    private InputField passwordRegisterField;
    [SerializeField]
    private InputField passwordRegisterVerifyField;
    [SerializeField]
    private Text warningRegisterText;


    private void Awake()
    {
        CreateInstance();
        if (emailLoginField.text == "" && passwordLoginField.text == "") {
            //Login
            emailLoginField.text = "i2@ludos.com";
            passwordLoginField.text = "test123";
            warningLoginText.text = "";
            confirmLoginText.text = "";
        }
    }

    private void CreateInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
   
    

    public void Login()
    {
        //Call the login coroutine passing the email and password
        AuthManger.Instance.Login(emailLoginField.text, passwordLoginField.text,warningLoginText,confirmLoginText);
    }
    //Function for the register button
    public void Register()
    {
        //Call the register coroutine passing the email, password, and username
        AuthManger.Instance.Register(emailRegisterField.text, passwordRegisterField.text,passwordRegisterVerifyField.text, UsernameRegisterField.text,warningRegisterText);
    }
    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        registrationPanel.SetActive(false);
    }

    public void OpenRegistrationPanel()
    {
        registrationPanel.SetActive(true);
        loginPanel.SetActive(false);
    }
    public void OpenGAME()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void OpenSelectplayer()
    {
        SceneManager.LoadScene("choosePlayer");
    }
    public void Openlogin()
    {
        SceneManager.LoadScene("FirebaseLogin");
        OpenLoginPanel();
    }

}
