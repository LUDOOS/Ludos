using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;
using UnityEngine.UI;

public class mangeplayer : MonoBehaviour
{
    [SerializeField] 
    private GameObject childrenPanel;
    [SerializeField] 
    private GameObject LoadingScreen;
    [SerializeField]
    private GameObject reload;
    [SerializeField]
    private List<Button> button;
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private GameObject parentButtonGameObject;
    private List<Children> childrens =  new List<Children>();
    [SerializeField]
    InputField childname;
    [SerializeField]
    InputField chilage;

    string ss;


    public void Getchild()
    {
        
         Query x = AuthManger.Instance.GetChildren();
        
         x.GetSnapshotAsync().ContinueWithOnMainThread(task =>
         {
            
             if (task.IsCompleted)
             {
                 

                 QuerySnapshot AllQuerySnapshot = task.Result;
                 foreach (DocumentSnapshot documentSnapshot in AllQuerySnapshot.Documents)
                 {
                     int i = int.Parse(documentSnapshot.Id)-1;
                     Debug.LogFormat($"Document data for document: {documentSnapshot.Id}");
                     childrens.Add(documentSnapshot.ConvertTo<Children>());
                     button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
                     button[i].name = childrens[i].Name;
                     button[i].GetComponentInChildren<Text>().text = childrens[i].Name;
                     ss = childrens[i].Avatar;
                     var s = Resources.Load<Sprite>(ss);
                     button[i].image.sprite = s;
                     button[i].onClick.AddListener(() => setPlayer());
                 }
                 LoadingScreen.SetActive(false);
                 reload.SetActive(false);
                 childrenPanel.SetActive(true);
             }
             else if (task.Exception != null)
             {
                 LoadingScreen.SetActive(false);
                 childrenPanel.SetActive(false);
                 reload.SetActive(true);
                 Debug.LogWarning(message: $"Failed to register task with {task.Exception}");
             }
         });
             
       
    }
    public void test()
    {
        var s = Resources.Load<Sprite>("avatar2");
        for (int i = 0; i < 2; i++)
        {
            button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
            button[i].name = i.ToString();
            button[i].GetComponentInChildren<Text>().text = i.ToString();
            button[i].image.sprite = s;
            button[i].onClick.AddListener(() => setPlayer());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Getchild();
        //test();
    }

    public Button CreateButton(Button buttonPrefab, GameObject parent)
    {
        var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, parent.transform) as Button;
        var rectTransform = button.GetComponent<RectTransform>();
        button.transform.localScale = Vector3.one;
        return button;
    }
    public void Logout()
    {
        AuthManger.Instance.LogOut();
    }
    public void AddChild()
    {
        AuthManger.Instance.AddChildren(childname.text, int.Parse(chilage.text));
        button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
        button[button.Count - 1].name = childname.text;
        button[button.Count - 1].GetComponentInChildren<Text>().text = childname.text;
        var s = Resources.Load<Sprite>("avatar1");
        button[button.Count - 1].image.sprite = s;
        button[button.Count - 1].onClick.AddListener(() => setPlayer());
        //OpenGAME
        //UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage");
    }
    private void setPlayer()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        foreach (Children child in childrens)
        {
            if (child.Name == name)
            {
                AuthManger.Instance.children = child;
            }
        }
        //OpenGAME
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamesPage");
    }
}
