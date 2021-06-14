using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [HideInInspector] public string TypeOfWeapon = "none";
    [SerializeField]private GameObject Aim;
    [SerializeField] private bool DEBUGING = false;
    [SerializeField] private bool DEBUGINGERRORS = true;
    [SerializeField] Weapon WeaponS;
    [SerializeField] ItemWeapon SOS;//treba da bude itemmanager
    private Animator anim;
    private string CurrentlyActiveWeapon = "None";
    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }
    void Update()
    {
        CurrentlyActiveWeapon = WeaponS.CurrentlyActiveWeapon;
        switch (Aim.transform.childCount)
        {
            case 0:
                Debuging("Nema Objekata u ruci");
            break;
            case 1:
                ChildCheckActive();
            break;
        }
        if(Aim.transform.childCount > 1)
        {
            DebugingError("Vise objekata u ruci");
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
        if(Aim.transform.childCount > 0)
        {
            for (int i = 0; i < Aim.transform.childCount; i++)
            {
                if (Aim.transform.GetChild(i).gameObject.activeSelf == true)//proveri da li je nesto aktivno
                {
                    //if (Aim.transform.GetChild(i).name == CurrentlyActiveWeapon)// ako jeste onda proveri da li je isti kao u drugoj scripti
                    //{              
                        anim.SetBool("Pistol", true);//i ako jeste onda upali animaciju
                        Debug.Log("Jeste ez");
                    //}
                    //else// ako nije onda pokazi debugging error
                    //{
                    //    DebugingError("Druga provera neuspesna, weapon nije pronadjen u bazi podataka");
                    //}
                }
                else
                {
                    if(ifNothingsActive(Aim) == true)//ako taj trenutni predmet nije aktivan onda proveri da li su svi neaktivni
                    {
                        Debuging("not active");//ako su svi neaktivni onda iskljuci svaku animaciju i stavi default type weapon
                        TypeOfWeapon = "None";
                        if(anim.GetBool("Pistol") is true || anim.GetBool("Gun") is true || anim.GetBool("Sword") is true )
                        {
                            HoldNothing();
                        }
                    }
                }
            }
        }
        else
        Debug.Log("Nije Veci od nule anim");
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
