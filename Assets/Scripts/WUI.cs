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
    [HideInInspector]public bool Populated1;
    [HideInInspector]public bool Populated2;
    [HideInInspector]public bool Populated3;
    [HideInInspector]public GameObject GO1;
    [HideInInspector]public GameObject GO2;
    [HideInInspector]public GameObject GO3;
    private Sprite icon;
    void Awake() //Svaki gameobject ce da zabelezi na pocetku
    {
        Populated1 = false;
        Populated2 = false;
        Populated3 = false;
        CheckSetGo();
    }
    void Update()
    {
        CheckSetGo();
        if(Input.GetKeyDown("1"))
        {
            holdFromHand("go1");
        }
        if(Input.GetKeyDown("2"))
        {
            holdFromHand("go2");
        }
        if(Input.GetKeyDown("3"))
        {
            holdFromHand("go3");
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
                        Populated1 = true;
                        text1.text = wim.Get(Item.name).name;
                        if(GO1 == null || GO1.name != Item.name)
                        {
                        GO1 = GameObject.Find(Item.name);
                        }

                    break;
                    case "Pistol":
                        //change icon wim.Get(Item.name).icon;
                        Populated2 = true;
                        text2.text = wim.Get(Item.name).name;
                        Debug.Log("pistol");
                        if(GO2 == null || GO2.name != Item.name)
                        {
                        GO2 = GameObject.Find(Item.name);
                        }
                        //Stavi description ako bude hover 

                    break;
                    case "Gun":
                        //change icon wim.Get(Item.name).icon;
                        Populated3 = true;
                        text3.text = wim.Get(Item.name).name;
                        if(GO3 == null || GO3.name != Item.name)
                        {
                        GO3 = GameObject.Find(Item.name);
                        }
                    break;
                    default:
                        
                    break;
                }
            }
        }
    }
    public void holdFromHand(string go)
    {
        switch (go)
        {
            case "go1":
            if(GO1.activeSelf == true)
            {
                GO1.SetActive(false);
            }
            else 
            {
                GO1.SetActive(true);
            }
            break;
            case "go2":
            if(GO2.activeSelf == true)
            {
                GO2.SetActive(false);
            }
            else 
            {
                GO2.SetActive(true);
            }
            break;
            case "go3":
            if(GO3.activeSelf == true)
            {
                GO3.SetActive(false);
            }
            else 
            {
                GO3.SetActive(true);
            }
            break;
            default:
            break;
        }
    }
}
