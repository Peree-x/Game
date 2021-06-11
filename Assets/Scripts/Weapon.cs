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

    private void Awake()
    {
        Aim = GameObject.Find("Aim"); //Aim
        check();
        //pronadji Bullet, BulletAIm (njegovo dete) i animaciju ako postoji
        BulletAim = GameObject.Find(CurrentlyActiveWeapon).transform.Find("BulletAim");//treba da se ponovi u update
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
            Rotate(BulletAim.transform.gameObject);//namesti da se ocita objekat koji treba da se rotira
            Debuging("player trazi rotaciju");
        }
        Debug.Log(playerx +""+ transform.localScale.x);
    }
    void Attack() //ako je canAttack true onda pokreni animaciju i pokreni udarac
    {
        if(canAttack == true)
        {

            Anim.SetBool("MouseClick", true);
            Instantiate(Bullet, BulletAim.position, BulletAim.rotation); //ovo je samo za gun treba da se prebaci u weapon da bi svaki put bilo drugacije
            SetInputDelay();//delay ce za svaki weapon biti isti, treba se prebaciti u weapon da bi mogao svaki da se podesava
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
        if(ToRotate.transform.rotation.z is -1)
        {
            ToRotate.transform.rotation = Quaternion.Euler(ToRotate.transform.rotation.x,ToRotate.transform.rotation.y,360);
            Debuging("rotiran na 0"+ ToRotate.transform.rotation.z);
        }
        else
        Debuging("nije nego"+ ToRotate.transform.rotation.z);
            if(ToRotate.transform.rotation.z == 0 || ToRotate.transform.rotation.z == 360)
            {
                ToRotate.transform.rotation = Quaternion.Euler(ToRotate.transform.rotation.x,ToRotate.transform.rotation.y, 180);
                Debuging("rotiran na 180"+ ToRotate.transform.rotation.z);
            }
        Debuging("" + ToRotate.transform.rotation.z);
        playerx = transform.localScale.x;
    }
    void SetInputDelay() //primeni delay
    {
        canAttack = false;
        Invoke("ClearInputDelay", inputDelay);
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
