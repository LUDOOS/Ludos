using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class AuthManger : MonoBehaviour
{
    public static AuthManger Instance { get; private set; }

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth firebaseAuth;
    public FirebaseUser firebaseUser;
    public FirebaseApp firebaseApp;
    public FirebaseFirestore firebaseFirestore;

    [Header("Firebase DATA")]
    public Children children;
    public Parent parent;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
           {
               var dependencyStatus = task.Result;
               if (dependencyStatus == DependencyStatus.Available)
               {
                   Debug.Log("DependencyStatus.Available");
                    // Create and hold a reference to your FirebaseApp,
                    // where firebaseApp is a Firebase.FirebaseApp property of your application class.
                    InitializeFirebase();
                    //CreateInstance();
                    // Set a flag here to indicate whether Firebase is ready to use by your firebaseApp.
                }
               else
               {
                   Debug.LogError(System.String.Format(
                     "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
           });
        }
        //Check that all of the necessary dependencies for Firebase are present on the system
    }
    private void InitializeFirebase()
    {
        firebaseApp = FirebaseApp.DefaultInstance;
        firebaseFirestore = FirebaseFirestore.GetInstance(firebaseApp);
        //Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        firebaseAuth = FirebaseAuth.GetAuth(firebaseApp);
        firebaseAuth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (firebaseAuth.CurrentUser != firebaseUser)
        {
            bool signedIn = firebaseUser != firebaseAuth.CurrentUser && firebaseAuth.CurrentUser != null;
            if (!signedIn && firebaseUser != null)
            {
                Debug.Log("Signed out " + firebaseUser.UserId);
            }
            firebaseUser = firebaseAuth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + firebaseUser.UserId);
                
            }
        }
    }

    

    private IEnumerator AddUserINFO()// for  parent 
    {

        yield return new WaitUntil(predicate: () => firebaseApp != null);//  foe make sure firebase is rady 

        yield return new WaitUntil(predicate: () => firebaseAuth != null);

        yield return new WaitUntil(predicate: () => firebaseFirestore != null);

        var parentRef = firebaseFirestore.Collection("parent").Document(firebaseUser.UserId);

        parent = new Parent(firebaseUser.DisplayName,NumberOfChildrens: 0, firebaseUser.Email);

        parentRef.SetAsync(parent).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.LogFormat("firebaseUser {0} Register successfully: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                UIManager.Instance.OpenLoginPanel();
            }
            else
            {
                Debug.LogFormat("firebaseUser {0} add data Failed: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                firebaseUser.DeleteAsync();
            }
        });
    }
    //TODO shall we do method for parent : Async ,Delete ,Update still we dont need username And email 
    public void AddChildren(string ChildName, int ChildAge)
    {
        parent.NumberOfChildrens++;//  update number of children for parent 
        var parentnRef = firebaseFirestore.Collection("parent").Document(firebaseUser.UserId);
        parentnRef.SetAsync(parent).ContinueWithOnMainThread(task =>
       {
           if (task.IsCompleted)
           {
                //Debug.LogFormat("firebaseUser add data is successfully: {0} ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                Debug.LogFormat("children {0} add successfully: ({1})", children.Name, firebaseUser.Email);
           }
           else
           {
               Debug.LogFormat("children {0} add  Failed: ({1})", children.Name, firebaseUser.Email);
           }
       });
       //object Avatar set Defalet 1
       // cetriate child data
        children = new Children(
            ID: parent.NumberOfChildrens,
            Avatar: "avatar1",
            Name: ChildName,
            Age: ChildAge,
            Total_stars: 0,
            Achievements: new ArrayList(),
            StoreItems: new ArrayList() { "avatar1" },
            Math: new ArrayList(),
            Calendar: new ArrayList(),
            Animals: new ArrayList(),
            completionState: new ArrayList() { false , false, false});

        var ChildrenRef = firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).Collection("children").Document(parent.NumberOfChildrens.ToString());
        ChildrenRef.SetAsync(children).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                //Debug.LogFormat("firebaseUser add data is successfully: {0} ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                Debug.LogFormat("children {0} add successfully: ({1})", children.Name, firebaseUser.Email);
            }
            else
            {
                Debug.LogFormat("children {0} add  Failed: ({1})", children.Name, firebaseUser.Email);

            }
        });
    }
    public void AsyncChildrenData(int childID)
    {

        if (childID > 0)
        {
            firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).Collection("children").Document(childID.ToString()).GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                children = task.Result.ConvertTo<Children>();
            });
        }
    }
    public void DeleteChildrenData(int childID)
    {
        if (parent.NumberOfChildrens > 0)
        {
            parent.NumberOfChildrens--;
            firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).Collection("children").Document(childID.ToString()).DeleteAsync();
            firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).SetAsync(parent).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    //Debug.LogFormat("firebaseUser add data is successfully: {0} ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                    Debug.LogFormat("firebaseUser {0} delete successfully: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                }
                else
                {
                    Debug.LogFormat("firebaseUser {0} delete Failed: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                    firebaseUser.DeleteAsync();
                }
            });
        }
    }
    public void SendChildrenData(int childID)
    {
        if (childID > 0)
        {
            firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).Collection("children").Document(childID.ToString()).SetAsync(children).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    //Debug.LogFormat("firebaseUser add data is successfully: {0} ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                    Debug.LogFormat("firebaseUser {0} SendChildrenData successfully: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                }
                else
                {
                    Debug.LogFormat("firebaseUser {0} SendChildrenData Failed: ({1})", firebaseUser.DisplayName, firebaseUser.Email);
                }
            });
        }
    }
    //Function for the login button
    public void Login(string _email, string _password, Text _warningLoginText)
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(LoginAsync(_email, _password, _warningLoginText));
    }
    //Function for the register button
    public void Register(string _email, string _password, string _Verifypassword, string _username, Text _warningRegisterText)
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(RegisterAsync(_email, _password, _Verifypassword, _username, _warningRegisterText));
    }
    private IEnumerator LoginAsync(string _email, string _password, Text warningLoginText)
    {
        //Call the Firebase firebaseAuth signin function passing the email and password
        var LoginTask = firebaseAuth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
                case AuthError.Failure:
                    UIManager.Instance.loginPanel.SetActive(true);
                    message = "Login Failed";
                    break;
            }
            warningLoginText.text = message;
            Debug.LogWarning(message);
        }
        else
        {
            UIManager.Instance.loginPanel.SetActive(false);
            UIManager.Instance.loadingScreen.SetActive(true);
            warningLoginText.text = "";
            yield return new WaitForSeconds(2.2f);
            //firebaseUser is now logged in
            //Now get the result
            firebaseUser = LoginTask.Result;
            firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                parent = task.Result.ConvertTo<Parent>();
            });
            //firebaseAuth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
            UIManager.Instance.OpenSelectplayer();
            Debug.LogFormat("firebaseUser signed is successfully: {0} ({1})", firebaseUser.DisplayName, firebaseUser.Email);
            SceneManager.LoadScene("choosePlayer");
        }
    }
    private IEnumerator RegisterAsync(string _email, string _password, string _Verifypassword, string _username, Text warningRegisterText)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Missing Username";
        }
        else if (_password != _Verifypassword)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            //Call the Firebase firebaseAuth signin function passing the email and password
            var RegisterTask = firebaseAuth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
                Debug.LogWarning(message);
            }
            else
            {
                //firebaseUser has now been created
                //Now get the result
                firebaseUser = RegisterTask.Result;

                if (firebaseUser != null)
                {
                    UserProfile profile = new() { DisplayName = _username };

                    //Call the Firebase firebaseAuth update user profile function passing the profile with the username
                    var ProfileTask = firebaseUser.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        firebaseUser.DeleteAsync();
                    }
                    else
                    {
                        StartCoroutine(AddUserINFO());
                    }
                }

            }
        }
    }
    //TODO Can bee better
    public IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new() { DisplayName = _username };

        //Call the Firebase firebaseAuth update user profile function passing the profile with the username
        var ProfileTask = firebaseUser.UpdateUserProfileAsync(profile);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            //Username is now set
        }
    }
    public IEnumerator UpdateEmailAuth(string _email)
    {
        var authTask = firebaseAuth.CurrentUser.UpdateEmailAsync(_email);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => authTask.IsCompleted);

        if (authTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {authTask.Exception}");
        }
        else
        {
            //_email is now set
        }
    }
    public IEnumerator UpdatePasswordAuth(string _password)
    {
        var authTask = firebaseAuth.CurrentUser.UpdatePasswordAsync(_password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => authTask.IsCompleted);

        if (authTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {authTask.Exception}");
        }
        else
        {
            //_password is now set
        }
    }
    public void LogOut()
    {
        Debug.LogFormat("user SignOut :{0} ({1}) ", firebaseUser.DisplayName, firebaseUser.Email);
        firebaseAuth.SignOut();
        if (GameObject.Find("GameManager") != null)
        {
            Destroy(GameObject.Find("GameManager"));
        }
        AuthStateChanged(this, null);
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirebaseLogin");
    }
    public Query GetChildren()
    {
        List<Children> childrens = new List<Children>();
        Query AllQuery = firebaseFirestore.Collection("parent").Document(firebaseUser.UserId).Collection("children");
        return AllQuery;
    }
    
    public void OnDestroy()
    {
        SendChildrenData(children.ID);
        firebaseAuth.StateChanged -= AuthStateChanged;
        firebaseAuth = null;
        
    }
}
