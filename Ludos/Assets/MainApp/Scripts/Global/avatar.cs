
using UnityEngine;
public class avatar : MonoBehaviour
{
    private void Awake()
    {
        Sprite s = Resources.Load<Sprite>($"avatar{AuthManger.Instance.children.Avatar}");

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

    }
}
