
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
    [SerializeField]
    private Text stars;

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
            items[i].name = img_name;// img path
            GetChildWithName(items[i], "price").GetComponent<Text>().text = "3";
            GetChildWithName(items[i], "avatar").GetComponent<Image>().sprite = s;
            if (!AuthManger.Instance.children.StoreItems.Contains(items[i].name))
            {
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => buy());
            }
            else if (items[i].name != AuthManger.Instance.children.Avatar)
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => sethandeler());
            }
            else
            {
                GetChildWithName(items[i], "buy").GetComponentInChildren<Text>().text = "set";
                GetChildWithName(items[i], "buy").GetComponent<Button>().onClick.AddListener(() => sethandeler());
                items[i].GetComponentInChildren<Button>().interactable = false;
            }
            
        }
    }
    private void buy()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
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
        
    
    private void sethandeler()
    {
        GameObject GO = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;

        GameObject temp = items.Where(obj => obj.name == AuthManger.Instance.children.Avatar)
                            .SingleOrDefault(); temp.GetComponentInChildren<Button>().interactable = true;
        //GetChildWithName(temp, "buy").GetComponent<Button>().onClick.AddListener(() => sethandeler());
        AuthManger.Instance.children.Avatar = GO.name;
        AuthManger.Instance.SendChildrenData(AuthManger.Instance.children.ID);
        GetChildWithName(GO, "buy").GetComponent<Button>().interactable = false;
    }

    void Awake()
    {
        stars.text = AuthManger.Instance.children.Total_stars.ToString();
        //StartCoroutine(Getshopitems());
       loadShop_Avatars();
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        
    }
}
