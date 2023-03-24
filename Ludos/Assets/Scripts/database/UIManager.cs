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
    private InputField emailLoginField;
    private InputField passwordLoginField;
    private Text warningLoginText;
    private Text confirmLoginText;

    //Register variables
    [Space]
    [Header("Register")]
    private InputField UsernameRegisterField;
    private InputField emailRegisterField;
    private InputField passwordRegisterField;
    private InputField passwordRegisterVerifyField;
    private Text warningRegisterText;


    private void Awake()
    {
        CreateInstance();
    }

    private void CreateInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
   
    private void Update()
    {
        //int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //emailLoginField = GameObject.Find("EmailInputField").GetComponent<InputField>();
        if (loginPanel.activeInHierarchy && loginPanel != null)
        {
            //Login
            emailLoginField = GameObject.Find("EmailInputField").GetComponent<InputField>();
            passwordLoginField = GameObject.Find("PasswordInputField").GetComponent<InputField>();
            warningLoginText = GameObject.Find("warningLoginText").GetComponent<Text>();
            confirmLoginText = GameObject.Find("confirmLoginText").GetComponent<Text>();
            //test
            if (emailLoginField.text == "" && passwordLoginField.text == "") {
                //Login
                emailLoginField.text = "test@ludos.com";
                passwordLoginField.text = "test123";
            }
        }
        else if (registrationPanel.activeInHierarchy && registrationPanel != null)
        {
            //Register
            UsernameRegisterField = GameObject.Find("UsernameRegisterField").GetComponent<InputField>();
            UsernameRegisterField = GameObject.Find("RegisterEmailInputField").GetComponent<InputField>();
            passwordRegisterField = GameObject.Find("RegisterPasswordInputField").GetComponent<InputField>();
            passwordRegisterVerifyField = GameObject.Find("RegisterConfirmPasswordInputField").GetComponent<InputField>();
            warningRegisterText = GameObject.Find("warningRegisterText").GetComponent<Text>();

            //test
            if (UsernameRegisterField.text == "" && emailRegisterField.text == "" && passwordRegisterField.text == "" && passwordRegisterVerifyField.text == "" )
            {
                //Register
                UsernameRegisterField.text = "test";
                emailRegisterField.text = "test@ludos.com";
                passwordRegisterField.text = "test123";
                passwordRegisterVerifyField.text = "test123";
            }
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
        SceneManager.LoadScene(23);
    }
    public void Openlogin()
    {
        SceneManager.LoadScene(22);
        OpenLoginPanel();
    }

}
