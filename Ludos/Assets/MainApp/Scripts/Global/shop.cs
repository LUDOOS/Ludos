
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class shop : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    public GameObject itemsPrefab;
    [SerializeField] private GameObject parentGameObject;
    [SerializeField] private Text stars;

    public GameObject CreateGameObject(GameObject Prefab, GameObject parent)
    {
        var temp = Object.Instantiate(Prefab, Vector3.zero, Quaternion.identity, parent.transform);
        var rectTransform = temp.GetComponent<RectTransform>();
        temp.transform.localScale = Vector3.one;
        return temp;
    }

    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public void loadShop_Avatars()
    {

        for (int i = 0; i < 25; i++)
        {
            string img_name = $"avatar{i + 1}";
            var s = Resources.Load<Sprite>(img_name);
            items.Add(CreateGameObject(itemsPrefab, parent: parentGameObject));
            items[i].name = img_name; // img path
            GetChildWithName(items[i], "price").GetComponent<Text>().text = "3";
            GetChildWithName(items[i], "avatar").GetComponent<Image>().sprite = s;
            if (!AuthManger.Instance.children.StoreItems.Contains(items[i].name))
            {
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => buy());
            }
            else if (items[i].name != AuthManger.Instance.children.Avatar)
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => setAvatar());
                GetChildWithName(items[i], "price").SetActive(false);
            }
            else
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => setAvatar());
                GetChildWithName(items[i], "price").SetActive(false);
                items[i].GetComponentInChildren<Button>().interactable = false;
            }

        }
    }

    private void buy()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent
            .gameObject;
        int price = int.Parse(GetChildWithName(GO, "price").GetComponentInChildren<Text>().text);
        Debug.Log(GO.name);

        if (!AuthManger.Instance.children.StoreItems.Contains(GO.name))
        {

            if (price <= AuthManger.Instance.children.Total_stars)
            {
                AuthManger.Instance.children.Total_stars -= price;
                stars.text = AuthManger.Instance.children.Total_stars.ToString();
                AuthManger.Instance.children.StoreItems.Add(GO.name);
                //more op
                GetChildWithName(GO, "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(GO, "buy").GetComponent<Button>().onClick.AddListener(() => setAvatar());
                GetChildWithName(GO, "price").SetActive(false);
               // AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
            }
            else
            {
                _ShowAndroidToastMessage("Not enough stars");
            }
        }
    }


   // previously named setHandler
    private void setAvatar()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent
            .gameObject;

        GameObject temp = items.Where(obj => obj.name == AuthManger.Instance.children.Avatar).SingleOrDefault();
        temp.GetComponentInChildren<Button>().interactable = true;

        Image avatarImg = GetChildWithName(GO, "avatar").GetComponent<Image>();
        avatarImg.color = new Color(0.5f,0.5f,0.5f,1);
        
        //GetChildWithName(temp, "buy").GetComponent<Button>().onClick.AddListener(() => setAvatar());
        AuthManger.Instance.children.Avatar = GO.name;
        //AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
        GetChildWithName(GO, "buy").GetComponent<Button>().interactable = false;
        GetChildWithName(GO, "avatar").GetComponent<Image>().color = new Color(207, 207, 207);
    }

    void Awake()
    {
        stars.text = AuthManger.Instance.children.Total_stars.ToString();
        //StartCoroutine(Getshopitems());
        loadShop_Avatars();
    }
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

}

