using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

public class AuthenticationManger : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    //public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public FirebaseApp app;

    ////Login variables
    //[Space]
    //[Header("Login")]
    //public InputField emailLoginField;
    //public InputField passwordLoginField;
    //public Text warningLoginText;
    //public Text confirmLoginText;

    ////Register variables
    //[Space]
    //[Header("Register")]
    //public InputField UsernameRegisterField;
    //public InputField emailRegisterField;
    //public InputField passwordRegisterField;
    //public InputField passwordRegisterVerifyField;
    //public Text warningRegisterText;

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    //private void Start()
    //{
    //    //for test 
    //    emailLoginField.text = "test@ludos.com";
    //    passwordLoginField.text = "test123";
    //}
    private void InitializeFirebase()
    {
        app = FirebaseApp.DefaultInstance;
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != User)
        {
            bool signedIn = User != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && User != null)
            {
                Debug.Log("Signed out " + User.UserId);
            }
            User = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + User.UserId);
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    //Function for the login button
    //public void Login()
    //{
    //    //Call the login coroutine passing the email and password
    //    StartCoroutine(LoginAsync(emailLoginField.text, passwordLoginField.text));
    //}
    //Function for the register button
    //public void Register()
    //{
    //    //Call the register coroutine passing the email, password, and username
    //    StartCoroutine(RegisterAsync(emailRegisterField.text, passwordRegisterField.text, UsernameRegisterField.text));
    //}
    //private IEnumerator LoginAsync(string _email, string _password)
    //{
    //    //Call the Firebase auth signin function passing the email and password
    //    var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
    //    //Wait until the task completes
    //    yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

    //    if (LoginTask.Exception != null)
    //    {
    //        //If there are errors handle them
    //        Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
    //        FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
    //        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

    //        string message = "Login Failed!";
    //        switch (errorCode)
    //        {
    //            case AuthError.MissingEmail:
    //                message = "Missing Email";
    //                break;
    //            case AuthError.MissingPassword:
    //                message = "Missing Password";
    //                break;
    //            case AuthError.WrongPassword:
    //                message = "Wrong Password";
    //                break;
    //            case AuthError.InvalidEmail:
    //                message = "Invalid Email";
    //                break;
    //            case AuthError.UserNotFound:
    //                message = "Account does not exist";
    //                break;
    //        }
    //        warningLoginText.text = message;
    //        Debug.LogWarning(message);
    //    }
    //    else
    //    {
    //        //User is now logged in
    //        //Now get the result
    //        User = LoginTask.Result;
    //        Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
    //        warningLoginText.text = "";
    //        confirmLoginText.text = "Logged In";
    //    }
    //}
    //private IEnumerator RegisterAsync(string _email, string _password, string _username)
    //{
    //    if (_username == "")
    //    {
    //        //If the username field is blank show a warning
    //        warningRegisterText.text = "Missing Username";
    //    }
    //    else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
    //    {
    //        //If the password does not match show a warning
    //        warningRegisterText.text = "Password Does Not Match!";
    //    }
    //    else
    //    {
    //        //Call the Firebase auth signin function passing the email and password
    //        var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
    //        //Wait until the task completes
    //        yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

    //        if (RegisterTask.Exception != null)
    //        {
    //            //If there are errors handle them
    //            Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
    //            FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
    //            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

    //            string message = "Register Failed!";
    //            switch (errorCode)
    //            {
    //                case AuthError.MissingEmail:
    //                    message = "Missing Email";
    //                    break;
    //                case AuthError.MissingPassword:
    //                    message = "Missing Password";
    //                    break;
    //                case AuthError.WeakPassword:
    //                    message = "Weak Password";
    //                    break;
    //                case AuthError.EmailAlreadyInUse:
    //                    message = "Email Already In Use";
    //                    break;
    //            }
    //            warningRegisterText.text = message;
    //            Debug.LogWarning(message);
    //        }
    //        else
    //        {
    //            //User has now been created
    //            //Now get the result
    //            User = RegisterTask.Result;

    //            if (User != null)
    //            {
    //                //Create a user profile and set the username
    //                UserProfile profile = new UserProfile { DisplayName = _username };

    //                //Call the Firebase auth update user profile function passing the profile with the username
    //                var ProfileTask = User.UpdateUserProfileAsync(profile);
    //                //Wait until the task completes
    //                yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

    //                if (ProfileTask.Exception != null)
    //                {
    //                    //If there are errors handle them
    //                    Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
    //                    FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
    //                    AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
    //                    warningRegisterText.text = "Username Set Failed!";
    //                }
    //                else
    //                {
    //                    //Username is now set
    //                    //Now return to login screen
    //                    //UIManager.instance.LoginScreen();
    //                    warningRegisterText.text = "";
    //                }
    //            }
    //        }
    //    }
    //}

}
