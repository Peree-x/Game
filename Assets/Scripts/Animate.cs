using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    bool postoji = false;
    GameObject Aim;
    public string TypeOfWeapon = "none";
    public bool DEBUGING = false;
    public bool DEBUGINGERRORS = true;
    public Animator anim;
    private void Awake()
    {
        Check();
        anim = GetComponent < Animator >();
    }
    void FixedUpdate()
    {
        if(postoji is true)//proveri da li postoji
        {
            if(Aim.transform.childCount > 0 && Aim.transform.childCount != 0)
            {
                ChildCheck();
            }
            else
                DebugingError("Vise objekata postoje u ruci");//obavesti o mogucoj greski
        }
    }
    void ChildCheck() //proveri za svakog child njegovo stanje (Da li je enable ili disable) i ako je enable nadji mu ime i pokreni animaciju za njega
    {
        for (int i = 0; i < Aim.transform.childCount; i++)
        {
            if (Aim.transform.GetChild(i).gameObject.activeSelf == true)
            {
                switch (Aim.transform.GetChild(i).name)//baza podataka o weapon
                {
                    case "Glock":
                        anim.SetBool("Pistol", true);
                        TypeOfWeapon = "Pistol";
                        Debuging("Weapon in arm is a " + TypeOfWeapon);
                        break;
                    case "0":
                        HoldNothing();
                        TypeOfWeapon = "None";
                        DebugingError("Druga provera neuspesna, weapon nije pronadjen u bazi podataka");
                        break;
                }
            }
            else
            {
                Debuging("not active");
                if( anim.GetBool("Pistol") is true || anim.GetBool("Gun") is true || anim.GetBool("Sword") is true )
                {
                    HoldNothing();
                }
            }
        }
    }
    void Check() //proverava da li GameObject Aim postoji i rezultat pise u console
    {
        if(GameObject.Find("Aim") != null)
        {
            postoji = true;
            Aim = GameObject.Find("Aim");
            Debuging("Aim gameobject postoji : true");
        }
        else
        {
            postoji = false;
            DebugingError("Aim gameobject postoji : false");
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
