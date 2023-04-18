
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items;
    private List<shopitem> shopitem;
    public GameObject itemsPrefab;
    [SerializeField]
    private GameObject parentGameObject;

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
    public IEnumerator Getshopitems()
    {
        var x = AuthManger.Instance.Getshopitems();
        yield return new WaitForSeconds(0.5F);
        shopitem = x;
        for (int i = 0; i < shopitem.Count; i++)
        {
            Sprite s = Resources.Load<Sprite>(shopitem[i].Img_path);
            items.Add(CreateGameObject(Prefab: itemsPrefab, parent: parentGameObject));
            items[i].name = shopitem[i].Img_path;
            items[i].GetComponentInChildren<Text>().text = "price: " + shopitem[i].Price.ToString();
            items[i].GetComponentInChildren<Image>().sprite = s;
            if (!AuthManger.Instance.children.StoreItems.Contains(items[i].name))
            {
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => buy());
            }
            else if (items[i].name != AuthManger.Instance.children.Avatar)
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() =>sethandeler());
            }
            else
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                items[i].GetComponentInChildren<Button>().interactable = false;
            }
        }
    }
    
public IEnumerator test()
    {
        yield return new WaitForSeconds(0);
        for (int i = 0; i < 25; i++)
        {
            string ss = $"avatar{i + 1}";
            var s = Resources.Load<Sprite>(ss);
            items.Add(CreateGameObject(itemsPrefab, parent: parentGameObject));
            items[i].name = ss;// img path
            GetChildWithName(items[i], "price").GetComponent<Text>().text = "price: test";
            GetChildWithName(items[i], "avatar").GetComponent<Image>().sprite = s;
        }
    }
    private void buy()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Debug.Log(GO.name);
        foreach (shopitem item in shopitem)
        {
            if (item.Name == GO.name)
            {
                if (!AuthManger.Instance.children.StoreItems.Contains(item.Img_path))
                {
                    
                    if (item.Price <= AuthManger.Instance.children.Total_stars)
                    {
                        AuthManger.Instance.children.Total_stars -= item.Price;
                        AuthManger.Instance.children.StoreItems.Add(item.Img_path);
                        //more op
                        GetChildWithName(GO, "buy").GetComponentInChildren<Text>().text = "set";
                        GetChildWithName(GO, "buy").GetComponent<Button>().onClick.AddListener(() => sethandeler());
                        AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
                    }
                    else
                    {
                        //TODO error not enough stars 
                        Debug.Log("not enough stars ");
                    }
                }
            }
        }
    }
    private void sethandeler()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;

        var temp = items.Where(obj => obj.name == AuthManger.Instance.children.Avatar)
                            .SingleOrDefault().GetComponentInChildren<Button>().interactable = true;
        GetChildWithName(GO, "buy").GetComponent<Button>().onClick.AddListener(() => sethandeler());
        AuthManger.Instance.children.Avatar = GO.name;
        AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
        GetChildWithName(GO, "buy").GetComponent<Button>().interactable = false;
    }

    void Awake()
    {
        StartCoroutine(Getshopitems());
        //StartCoroutine(test());
    }


    // Update is called once per frame
    void Update()
    {

    }
}
