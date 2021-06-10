using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject Bullet;
    public GameObject GlockBullet;
    private Transform BulletAim;
    public float inputDelay = 0.3f;
    private Animator Anim;
    bool canAttack;
    private GameObject Aim;
    public bool DEBUGGING;
    public bool DEBUGGINGERROR;
    string[] Weapons;
    string CurrentlyActiveWeapon;

    void Awake()
    {
        check();
        //pronadji Bullet, BulletAIm (njegovo dete) i animaciju ako postoji
        Aim = GameObject.Find("Aim"); //Aim
        BulletAim = GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim");//treba da se ponovi u update
        //pronadji bullet tako sto ces da napravis listu svakog gun i staviti bullet koji koristi pa iz te liste asistirati bullet
        bullet();
        AnimCheck();
        
    }
    private void Start()
    {
        for(int i = 0;i < Aim.transform.childCount; i++)
        {
            Weapons[i] = Aim.transform.GetChild(i).name;
            Debuging(Aim.transform.GetChild(i).name);
        }
    }

    void Update()
    {
        check();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        if(canAttack is true)
        {
            SetInputDelay();
            Anim.SetBool("MouseClick", true);
            Instantiate(Bullet, BulletAim.position, BulletAim.rotation);
        }
        else
        {
            Debuging("CanAttack is false");
        }
    }
    void check()
    {
        for (int i = 0; i < Aim.transform.childCount; i++)
        {
            if (Aim.transform.GetChild(i).gameObject.activeSelf == true)
            {
                canAttack = true;
                CurrentlyActiveWeapon = Aim.transform.GetChild(i).name;
            }
            else //ovo pravi bugove ako ih ima vise smisli bolji nacin
            {
                canAttack = false;
            }
        }
    }
    void bullet()
    {
        switch (CurrentlyActiveWeapon)
        {
            case "Glock":
                Bullet = GlockBullet;
                break;
            case "0":
                //sword ili nije nista
                break;
        }
    }
    void AnimCheck()
    {
        if (GameObject.Find(CurrentlyActiveWeapon).GetComponent<Animator>() != null)
        {
            Anim = GameObject.Find(CurrentlyActiveWeapon).GetComponent<Animator>();
        }
    }
    void SetInputDelay()
    {
        canAttack = false;
        Invoke("ClearInputDelay", inputDelay);
    }

    void ClearInputDelay()
    {
        canAttack = true;
    }
    void Debuging(string obavestava)
    {
        if (DEBUGGING is true)
        {
            Debug.Log(obavestava);
        }
    }
    void DebugingError(string obavestava1)
    {
        if (DEBUGGINGERROR is true)
        {
            Debug.Log(obavestava1);
        }
    }
}
