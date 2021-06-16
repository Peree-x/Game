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
    bool Populated1;
    bool Populated2;
    bool Populated3;
    private Sprite icon;
   // string[] x;
   // string[] y;
    //private int aimChildCount;
    void Awake() //Svaki gameobject ce da zabelezi na pocetku
    {
        Populated1 = false;
        Populated2 = false;
        Populated3 = false;
        //aimChildCount = GameObject.FindWithTag("Aim").transform.childCount;
      //  AssignX(aimChildCount);
       // x = y;
    }
    void Update()
    {
        CheckSetGo();
       // AssignX(aimChildCount);
    //    Debug.Log("childcount je "+aimChildCount);
    //    Debug.Log("xd1");
    //    Debug.Log(aimChildCount);
    //    for(int i = 0; i>aimChildCount;i++)
    //    {
    //        x[i] = GameObject.FindWithTag("Aim").transform.GetChild(i).name;
    //        Debug.Log("x je"+x[i]);
    //        Debug.Log("xd2");
    //    }
   //     if(x != y)
   //     {
   //         for (int i = 0; i < y.Length; i++)
   //         {
   //             if(x[i]!=y[i])
   //             {
   //                 if(x[i] == null)
   //                 {
   //                     remove(wim.Get(y[i]).typeofw.ToString());
   //                 }
   //             }
   //         }
   //         x=y;
   //     }
//        for(int i = 0; i > Populated.Length ; i++)
//        {
//            if(Populated[i] != true)
//            {
//                remove(i);
//            }
//        }
//        proveri dali je idalje true i ako jeste onda mu ne radi nista a ako nije onda upotrebi funkciju remove();
    }
    //void remove(string i)
    //{
    //    switch(i)
    //    {
    //        case "Sword":
    //            //image remove
    //            text1.text = null;
    //        break;
    //        case "Pistol":
    //            //image remove
    //            text2.text = null;
    //        break;
    //        case "Gun":
    //            //image remove
    //            text3.text = null;
    //        break;
    //    }
//
    //}
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
                        Populated1 = true;
                        text1.text = wim.Get(Item.name).name;

                    break;
                    case "Pistol":
                        //change icon wim.Get(Item.name).icon;
                        Populated2 = true;
                        text2.text = wim.Get(Item.name).name;
                        Debug.Log("pistol");
                        //Stavi description ako bude hover 

                    break;
                    case "Gun":
                        //change icon wim.Get(Item.name).icon;
                        Populated3 = true;
                        text3.text = wim.Get(Item.name).name;
                    break;
                    default:
                        
                    break;
                }
            }
        }
    }
}
