
using UnityEngine;

public class avatar : MonoBehaviour
{
    private void Awake()
    {
        Sprite s = Resources.Load<Sprite>($"avatar{AuthManger.Instance.children.Avatar}");
        string name = AuthManger.Instance.children.Name;
        if (gameObject.GetComponent<UnityEngine.UI.Image>() != null)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = s;
        }
        else if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = s;
        }
        else
        {
            Debug.Log("not find gameObject sprite");
        }

        if (gameObject.GetComponent<UnityEngine.UI.Text>() != null) {

            gameObject.GetComponent<UnityEngine.UI.Text>().text = name;
        }
        else if (gameObject.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {

            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
        }
        else
        {
            Debug.Log(" gameObject not found (name) ");
        }

    }
}
