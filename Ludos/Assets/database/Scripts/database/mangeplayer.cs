using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mangeplayer : MonoBehaviour
{
    //public Button[] button ;
    [SerializeField]
    private List<Button> button;
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private GameObject parentButtonGameObject;
    private List<Children> childrens;
    [SerializeField]
    InputField childname;
    [SerializeField]
    InputField chilage;

    string ss;


    public IEnumerator Getchild()
    {
        var x = AuthManger.Instance.GetChildren();
        //var s = Resources.Load<Sprite>(ss);
        yield return new WaitForSeconds(0.5F);
        childrens = x;
        for (int i = 0; i < childrens.Count; i++)
        {
            //button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject, position: new Vector3(x: 0F, y: 0F + ((float)i * -2.0F), z: 0F)));
            button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
            button[i].name = childrens[i].Name;
            button[i].GetComponentInChildren<Text>().text = childrens[i].Name;
            ss = $"avatar{childrens[i].Avatar}";
            var s = Resources.Load<Sprite>(ss);
            button[i].image.sprite = s;
            button[i].image.SetNativeSize();
            button[i].onClick.AddListener(() => setPlayer());
            //Debug.Log(i);
        }
    }
    //public IEnumerator test()
    //{
    //    //var x = AuthManger.Instance.GetChildren();
    //    var s = Resources.Load<Sprite>("avatar2");
    //    yield return new WaitForSeconds(1.5F);
    //    //childrens = x;
    //    //Debug.Log(childrens.Count);
    //    for (int i = 0; i < 100; i++)
    //    {
    //        //button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject, position: new Vector3(x: 0F, y: 0F + ((float)i * -2.0F), z: 0F)));
    //        button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
    //        button[i].name = i.ToString();
    //        button[i].GetComponentInChildren<Text>().text = i.ToString();
    //        //button[i].image.sprite = Resources.Load<Sprite>($"Assets/Sprites/Global/Avatars/avatar{(int)childrens[i]._Avatar}");
    //        button[i].image.sprite = s;
    //        button[i].image.SetNativeSize();
    //        button[i].onClick.AddListener(() => setPlayer());
    //        //Debug.Log(i);
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Getchild());
        //StartCoroutine(test());
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
    public void AddChild() {
        AuthManger.Instance.AddChildren(childname.text, int.Parse(chilage.text));
        //OpenGAME
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private void setPlayer()
    {
        string name =UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        foreach (Children child in childrens) {
            if (child.Name == name) {
                AuthManger.Instance.children = child;
            }
        }
        //OpenGAME
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
