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
    float playerx;
    private bool BulletAimExist;
    [SerializeField] private Glock GlockScr;

    private void Awake()
    {
        Aim = GameObject.Find("Aim"); //Aim
        check();
        //pronadji Bullet, BulletAIm (njegovo dete) i animaciju ako postoji
        if (GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim") != null)
        {
            BulletAim = GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim");//treba da se ponovi u update
        }
        //pronadji bullet tako sto ces da napravis listu svakog gun i staviti bullet koji koristi pa iz te liste asistirati bullet
        bullet();
        AnimCheck();
        playerx = transform.localScale.x;
    }
    void Update()
    {
        check();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        //ako je scale.x od playera drugaciji od pribelezenog onda aktiviraj rotate(GameObject koji treba da se rotira);
        if(transform.localScale.x != playerx)
        {
            playerx = transform.localScale.x;
            Debuging("player trazi rotaciju");
            if(BulletAim != null)
            {
            Rotate(GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim").gameObject);//namesti da se ocita objekat koji treba da se rotira
            }
        }
        if (GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim") != null)
        {
            BulletAimExist = true;
        }
        else
        {
            BulletAimExist = false;
        }
    }
    void Attack() //ako je canAttack true onda pokreni animaciju i pokreni udarac
    {
        if(canAttack == true)
        {

            Anim.SetBool("MouseClick", true);
            
            switch(CurrentlyActiveWeapon)
            {
                case "Glock":
                GlockScr.InstantiateBullet(BulletAim);
                SetInputDelay(GlockScr.speedOfShooting);
                break;
            } 
            //ovo je samo za gun treba da se prebaci u weapon da bi svaki put bilo drugacije
            //delay ce za svaki weapon biti isti, treba se prebaciti u weapon da bi mogao svaki da se podesava
        }
        else
        {
            Debuging("CanAttack is false");
        }
    }
    void check() //proverava da li je weapon u ruci i ako jeste onda proverava koj je u pitanju i postavlja da moze da udara
    {
        for (int i = 0; i < Aim.transform.childCount; i++)
        {
            if (Aim.transform.GetChild(i).gameObject.activeSelf == true) //ako je neki weapon aktivan pribelezi koji je i ukulji canAttack
            {
                canAttack = true;
                CurrentlyActiveWeapon = Aim.transform.GetChild(i).name;
                break;
            }
            else //ovo pravi bugove ako ih ima vise smisli bolji nacin
            {
                canAttack = false;
            }
        }
    }
    void bullet() //proveri koj bullet se koristi
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
    void AnimCheck() //proveri da li animacija postoji i ako postoji onda je dodeljuje u anim
    {
        if (GameObject.Find(CurrentlyActiveWeapon).GetComponent<Animator>() != null)
        {
            Anim = GameObject.Find(CurrentlyActiveWeapon).GetComponent<Animator>();
        }
        else
        {
            Debuging("Animation does not exist/script weapon");
        }
    }
    void GetWeapons() //not in use
    {
        for(int i = 0;i < Aim.transform.childCount; i++)
        {
            Weapons[i] = Aim.transform.GetChild(i).name;
            Debuging(Aim.transform.GetChild(i).name);
        }
    }
    void Rotate(GameObject ToRotate)
    {
        Debuging("player se rotiorao");
        //rotiraj tako sto ces da pomnozis scale.x sa -1
        switch(ToRotate.transform.eulerAngles.z)
        {
            case 180: 
                ToRotate.transform.rotation = Quaternion.Euler(0,0,0);
                Debuging("Ugao od 0 stepeni je postavljen na bulletaim");
            break;
            case 0: 
                ToRotate.transform.rotation = Quaternion.Euler(0,0,180);
                Debuging("Ugao od 180 stepeni je postavljen na bulletaim");
            break;
        }
    }
    void SetInputDelay(float Delay) //primeni delay
    {
        canAttack = false;
        Invoke("ClearInputDelay", Delay);
        Debuging("delay se aktivirao");
    }

    void ClearInputDelay()//primenjen delay posle izvesnog vremena menja funkciju
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
