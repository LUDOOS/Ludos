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
        yield return new WaitForSeconds(1F);
        childrens = x;
        //Debug.Log(childrens.Count);
        for (int i = 0; i < childrens.Count; i++)
        {
            //button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject, position: new Vector3(x: 0F, y: 0F + ((float)i * -2.0F), z: 0F)));
            button.Add(CreateButton(buttonPrefab: buttonPrefab, parent: parentButtonGameObject));
            button[i].name = childrens[i]._Name;
            button[i].GetComponentInChildren<Text>().text = childrens[i]._Name;
            ss = $"avatar{childrens[i]._Avatar}";
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
    //    for (int i = 0; i < 5; i++)
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

    // Update is called once per frame

    public  Button CreateButton(Button buttonPrefab, Canvas canvas, Vector2 cornerTopRight, Vector2 cornerBottomLeft)
    {
        var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(canvas.transform);
        rectTransform.anchorMax = cornerTopRight;
        rectTransform.anchorMin = cornerBottomLeft;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        //button.onClick.AddListener(()=>setPlayer());
        return button;
    }
    public Button CreateButton(Button buttonPrefab, GameObject parent)
    {

        var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, parent.transform) as Button;
        //button.transform.position =  new Vector3(x: 0F, y: 0F + ((float)position * -2.0F), z: 0F);
        var rectTransform = button.GetComponent<RectTransform>();
        //rectTransform.SetParent(parent.transform);
        //rectTransform.sizeDelta.Set(newX: 500F, newY: 500F);
        //rectTransform.localScale.Scale(Vector3.one);
        button.transform.localScale = Vector3.one;
        //rectTransform.anchorMax = buttonPrefab.GetComponent<RectTransform>().anchorMax;
        //rectTransform.anchorMin = buttonPrefab.GetComponent<RectTransform>().anchorMax;
        //rectTransform.offsetMax = buttonPrefab.GetComponent<RectTransform>().anchorMax;
        //rectTransform.offsetMin = buttonPrefab.GetComponent<RectTransform>().anchorMax;
        //button.onClick.AddListener(()=>setPlayer());
        return button;
    }
    public void Logout()
    {

        AuthManger.Instance.LogOut();
    }
    public void AddChild() {
        AuthManger.Instance.AddChildren(childname.text, int.Parse(chilage.text));
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    private void setPlayer()
    {
        string name =UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        foreach (Children child in childrens) {
            if (child._Name == name) {
                AuthManger.Instance.Children = child;
            }
        }
        //UIManager.Instance.OpenGAME();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
