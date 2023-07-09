using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Button [] achievements;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        var achList = AuthManger.Instance.children.Achievements; 
        for (int i = 0; i < achList.Count ; i++)
        {
            if (achList[i])
            {
                achievements[i].interactable = true;
            }
        }
    }
}
