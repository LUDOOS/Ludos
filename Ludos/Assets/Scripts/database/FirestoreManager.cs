//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;

public class FirestoreManager : MonoBehaviour
{
    [SerializeField] Button updateCountButton;
    [SerializeField] Text countUI;
    FirebaseFirestore db;
    Firebase.Auth.FirebaseUser User = AuthManger.Instance.User;
    ListenerRegistration listenerRegistration;
    // Start is called before the first frame update
    private void Start()
    {
        db = AuthManger.Instance.db;
        //db = FirebaseFirestore.DefaultInstance;

        updateCountButton.onClick.AddListener(OnHandleClick);
        listenerRegistration = db.Collection("counters").Document(User.UserId).Listen(snapshot =>
        {
            Counter counter = snapshot.ConvertTo<Counter>();
            countUI.text = counter.Count.ToString();
        });
    }
    void OnDestroy()
    {
        listenerRegistration.Stop();
    }
    void OnHandleClick()
    {
        int oldCount = int.Parse(countUI.text);
        // Using Structs
        Counter counter = new()
        {
            Count = oldCount + 1,
            UpdatedBy = User.DisplayName,
        };

        DocumentReference countRef = db.Collection("counters").Document(User.UserId);
        countRef.SetAsync(counter).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogFormat("Updated Counter: {0} ({1})", User.DisplayName, User.Email);
            }
            else if (task.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {task.Exception}");
            }
        });

    }
    void GetData()
    {
        db.Collection("counters").Document(User.UserId).GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            Counter counter = task.Result.ConvertTo<Counter>();
            countUI.text = counter.Count.ToString();
        });
    }

    public void Logout() {

        AuthManger.Instance.LogOut();
    }





}