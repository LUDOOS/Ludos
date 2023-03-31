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
    public FirebaseAuth auth;
    public FirebaseUser User;
    public FirebaseApp app;
    public FirebaseFirestore db;

    [Header("Firebase DATA")]
    public Children Children;
    public Parent parent;


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
                    // where app is a Firebase.FirebaseApp property of your application class.
                    InitializeFirebase();
                    //CreateInstance();
                    // Set a flag here to indicate whether Firebase is ready to use by your app.
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
        //Debug.Log("InitializeFirebase");
        app = FirebaseApp.DefaultInstance;
        db = FirebaseFirestore.GetInstance(app);
        //Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.GetAuth(app);
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
                SceneManager.LoadScene("choosePlayer");
            }
        }
    }

    
    //void OnDestroy()
    //{
    //    // some times make error try commint it 
    //    this.auth.StateChanged -= AuthStateChanged;
    //    this.auth = null;
    //}

    private IEnumerator AddUserINFO() {

        yield return new WaitUntil(predicate: () => app != null);
        //Debug.Log(app);
        yield return new WaitUntil(predicate: () => auth != null);
        //Debug.Log(auth);
        yield return new WaitUntil(predicate: () => db != null);
        //Debug.Log(db);
        //var docRef = db.Collection("counters").Document(User.UserId);

        var parentRef = db.Collection("parent").Document(User.UserId);
        //Counter counter = new Counter(0, User.DisplayName);
        parent = new Parent(User.DisplayName, 0, User.Email);
        //docRef.SetAsync(counter).ContinueWithOnMainThread(task =>
        parentRef.SetAsync(parent).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted) {
                //Debug.LogFormat("User add data is successfully: {0} ({1})", User.DisplayName, User.Email);
                Debug.LogFormat("User {0} Register successfully: ({1})", User.DisplayName, User.Email);
                UIManager.Instance.OpenLoginPanel();
            } else {
                Debug.LogFormat("User {0} add data Failed: ({1})", User.DisplayName, User.Email);
                User.DeleteAsync();
            }
        });
    }
    //TODO shall we do method for parent : Async ,Delete ,Update still we dont need username And email 
    public void AddChildren( string ChildName,int ChildAge) {
        //TODO object Avatar set Defalet 1
        parent.NoChildren++;
        var parentnRef = db.Collection("parent").Document(User.UserId);
        parentnRef.SetAsync(parent).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                //Debug.LogFormat("User add data is successfully: {0} ({1})", User.DisplayName, User.Email);
                Debug.LogFormat("Children {0} add successfully: ({1})", Children.Name, User.Email);
            }
            else
            {
                Debug.LogFormat("Children {0} add  Failed: ({1})", Children.Name, User.Email);
            }
        });
    
        Children = new Children(parent.NoChildren,1,ChildName,ChildAge,0, new ArrayList() {}, new ArrayList() {}, new ArrayList() { false }, new ArrayList() { false }, new ArrayList() { false }, new ArrayList() { false });
        var ChildrenRef = db.Collection("parent").Document(User.UserId).Collection("Children").Document(parent.NoChildren.ToString());
        ChildrenRef.SetAsync(Children).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                //Debug.LogFormat("User add data is successfully: {0} ({1})", User.DisplayName, User.Email);
                Debug.LogFormat("Children {0} add successfully: ({1})", Children.Name, User.Email);
            }
            else
            {
                Debug.LogFormat("Children {0} add  Failed: ({1})", Children.Name, User.Email);

            }
        });
    }
    public void AsyncChildrenData(int NoChildren)
    {

        if (NoChildren > 0)
        {
            db.Collection("parent").Document(User.UserId).Collection("Children").Document(NoChildren.ToString()).GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                Children = task.Result.ConvertTo<Children>();
            });
        }
    }
    public void DeleteChildrenData(int NoChildren)
    {
        if (parent.NoChildren > 0)
        {
            parent.NoChildren--;
            db.Collection("parent").Document(User.UserId).Collection("Children").Document(NoChildren.ToString()).DeleteAsync();
            db.Collection("parent").Document(User.UserId).SetAsync(parent).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                //Debug.LogFormat("User add data is successfully: {0} ({1})", User.DisplayName, User.Email);
                Debug.LogFormat("User {0} delete successfully: ({1})", User.DisplayName, User.Email);
                }
                else
                {
                    Debug.LogFormat("User {0} delete Failed: ({1})", User.DisplayName, User.Email);
                    User.DeleteAsync();
                }
            });
        }
    }
    private void SendChildrenData(int NoChildren)
    {
        if (NoChildren > 0)
        {
            db.Collection("parent").Document(User.UserId).Collection("Children").Document(NoChildren.ToString()).SetAsync(Children).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    //Debug.LogFormat("User add data is successfully: {0} ({1})", User.DisplayName, User.Email);
                    Debug.LogFormat("User {0} Register successfully: ({1})", User.DisplayName, User.Email);
                }
                else
                {
                    Debug.LogFormat("User {0} add data Failed: ({1})", User.DisplayName, User.Email);
                }
            });
        }
    }

    // to use from games 
    public void UpdateChildrenData(int NoChildren, object ChildrenItem, int ArrayIndex, object ChangedValue)
    {
        if (NoChildren > 0)
        {
            System.Type s = typeof(string);
            System.Type i = typeof(int);
            System.Type ar = typeof(ArrayList);
            System.Type test = ChildrenItem.GetType();
            if (test == s || test == i)
            {
                ChildrenItem = ChangedValue;
                SendChildrenData(NoChildren);
            }
            else if (test == ar)
            {
                ArrayList temp = (ArrayList)ChildrenItem;
                temp[ArrayIndex] = ChangedValue;
                ChildrenItem = temp;
                temp = null;
                SendChildrenData(NoChildren);
            }
            s = i = ar = test = null;
            //GC is garbage collector
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }
    public void UpdateChildrenData(int NoChildren, object ChildrenItem, object ChangedValue)
    {
        if (NoChildren > 0)
        {
            System.Type s = typeof(string);
            System.Type i = typeof(int);
            System.Type test = ChildrenItem.GetType();
            if (test == s || test == i)
            {
                ChildrenItem = ChangedValue;
                SendChildrenData(NoChildren);
            }
            s = i = test = null;
            //GC is garbage collector
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }

    //Function for the login button
    public void Login(string _email, string _password,Text _warningLoginText, Text _confirmLoginText)
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(LoginAsync(_email,_password, _warningLoginText, _confirmLoginText));
    }
    //Function for the register button
    public void Register(string _email, string _password, string _Verifypassword, string _username, Text _warningRegisterText)
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(RegisterAsync(_email, _password,_Verifypassword, _username,_warningRegisterText));
    }
    private IEnumerator LoginAsync(string _email, string _password,Text warningLoginText,Text confirmLoginText)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
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
            }
            warningLoginText.text = message;
            Debug.LogWarning(message);
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            db.Collection("parent").Document(User.UserId).GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                parent = task.Result.ConvertTo<Parent>();
            });
            //auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
            UIManager.Instance.OpenSelectplayer();
            Debug.LogFormat("User signed is successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In....";
        }
    }
    private IEnumerator RegisterAsync(string _email, string _password, string _Verifypassword, string _username,Text warningRegisterText)
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
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
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
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    UserProfile profile = new() { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        User.DeleteAsync();
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
    public  IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new() { DisplayName = _username };

        //Call the Firebase auth update user profile function passing the profile with the username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
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
    public IEnumerator UpdateEmailAuth(string _email) {
        var authTask = auth.CurrentUser.UpdateEmailAsync(_email);
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
        var authTask = auth.CurrentUser.UpdatePasswordAsync(_password);
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
        Debug.LogFormat("user SignOut :{0} ({1}) ", User.DisplayName, User.Email);
        auth.SignOut();
        AuthStateChanged(this, null);
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirebaseLogin");
    }
    public List<Children> GetChildren() {
        List<Children> childrens = new List<Children>();
        Query AllQuery = db.Collection("parent").Document(User.UserId).Collection("Children");
        AllQuery.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                QuerySnapshot AllQuerySnapshot = task.Result;
                foreach (DocumentSnapshot documentSnapshot in AllQuerySnapshot.Documents)
                {
                    //Debug.LogFormat($"Document data for document: {documentSnapshot.Id}");
                    childrens.Add(documentSnapshot.ConvertTo<Children>());                }
            }
            else if (task.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {task.Exception}");
            }
        });
        return childrens;
    }

}
