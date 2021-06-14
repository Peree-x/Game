using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private WeaponItemManager wim;
    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    bool[] Populated;
    bool[] bol;
    private Sprite icon;
    private void Update()
    {
        CheckSetGo();
//        for(int i = 0; i > Populated.Length ; i++)
//        {
//            if(Populated[i] != true)
//            {
//                remove(i);
//            }
//        }
//        proveri dali je idalje true i ako jeste onda mu ne radi nista a ako nije onda upotrebi funkciju remove();
    }
    void remove(int i)
    {
        switch(i)
        {
            case 0:
                //image remove
                text1.text = null;
            break;
            case 1:
                //image remove
                text2.text = null;
            break;
            case 2:
                //image remove
                text3.text = null;
            break;
        }

    }
    void CheckSetGo()
    {
        foreach (Transform Item in GameObject.FindWithTag("Aim").transform)
        {
            if(Item.gameObject.tag == "Weapon")
            {
                switch(wim.Get(Item.name).typeofw.ToString())
                {
                    case "Sword":
                        //change icon wim.Get(Item.name).icon;
                        Populated[0] = true;
                        text1.text = wim.Get(Item.name).name;

                    break;
                    case "Pistol":
                        //change icon wim.Get(Item.name).icon;
                        Populated[1] = true;
                        text2.text = wim.Get(Item.name).name;
                        Debug.Log("pistol");
                        //Stavi description ako bude hover 

                    break;
                    case "Gun":
                        //change icon wim.Get(Item.name).icon;
                        Populated[2] = true;
                        text3.text = wim.Get(Item.name).name;
                    break;
                    default:
                        
                    break;
                }
            }
        }
    }
}
