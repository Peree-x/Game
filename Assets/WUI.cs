using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private WeaponItemManager wim;
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    bool Populated1;
    bool Populated2;
    bool Populated3;
    private Sprite icon;
    private void Update()
    {
        foreach (Transform Item in GameObject.Find("Aim").transform)
        {
            if(Item.gameObject.tag == "Weapon")
            {
                switch(wim.Get(Item.name).typeofw.ToString())
                {
                    case "Sword":
                        //change icon wim.Get(Item.name).icon;
                        Text text1;
                        Populated1 = true;
                        text1 = Button1.GetComponentInChildren<Text>();
                        text1.text = wim.Get(Item.name).name;

                    break;
                    case "Pistol":
                        //change icon wim.Get(Item.name).icon;
                        Text text2;
                        Populated2 = true;
                        text2 = Button2.transform.Find("Text").gameObject.GetComponent<Text>();
                        text2.text = wim.Get(Item.name).name;
                        //Stavi description ako bude hover 

                    break;
                    case "Gun":
                        //change icon wim.Get(Item.name).icon;
                        Text text3;
                        Populated3 = true;
                        text3 = Button3.GetComponentInChildren<Text>();
                        text3.text = wim.Get(Item.name).name;
                    break;
                    default:
                        
                    break;
                }
            }
        }
    }
}
