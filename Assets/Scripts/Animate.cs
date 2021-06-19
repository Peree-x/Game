using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] private WeaponItemManager weaponItemManager;
    [SerializeField] private bool DEBUGING = false;
    [SerializeField] private bool DEBUGINGERRORS = true;
    [HideInInspector] public string TypeOfWeapon = "none";
    private GameObject Aim;
    private ItemWeapon ScriptableObject;
    private Animator anim;
    private string CurrentlyActiveWeapon;
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
        Aim = GameObject.FindWithTag("Aim");
    }
    void Update()
    {
        if(GameObject.FindWithTag("Weapon") != null)
        {
        CurrentlyActiveWeapon = GameObject.FindWithTag("Weapon").name;
        ScriptableObject = weaponItemManager.Get(CurrentlyActiveWeapon);
        }
        else 
        {
            CurrentlyActiveWeapon = null;
            ScriptableObject = null;
        }
        switch (Aim.transform.childCount)
        {
            case 0:
                Debuging("Nema Objekata u ruci");
            break;
            case 1:
                ChildCheckActive();
            break;
        }
    }
    bool ifNothingsActive(GameObject Target)
    {
        foreach(GameObject x in Target.transform)
        {
            if(x.activeSelf == true)
            {
                return false;
            }
        }
        return true;
    }
    void ChildCheckActive() //proveri za svakog child njegovo stanje (Da li je enable ili disable) i ako je enable nadji mu ime i pokreni animaciju za njega
    {
        if (GameObject.FindWithTag("Weapon") != null)//proveri da li je nesto aktivno
        {        
            switch (ScriptableObject.typeofw.ToString())
            {
                case "Pistol":
                    anim.SetBool("Pistol", true);
                break;
                case "Gun":
                    anim.SetBool("Gun", true);
                break;
                case "Sword":
                    anim.SetBool("Sword", true);
                break;
                default:
                break;
            }   
        }
        else
        {
            anim.SetBool("Pistol", false);
            anim.SetBool("Gun", false);
            anim.SetBool("Sword", false);
        }
    }
    void Debuging(string obavestava)
    {
        if (DEBUGING is true)
        {
            Debug.Log(obavestava);
        }
    }
    void DebugingError(string obavestava1)
    {
        if (DEBUGINGERRORS is true)
        {
            Debug.Log(obavestava1);
        }
    }
    void HoldNothing()
    {
        anim.SetBool("Pistol", false);
        anim.SetBool("Gun", false);
        anim.SetBool("Sword", false);
    }
}
