using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject Aim;
    [SerializeField] private WeaponItemManager WIM;
    [SerializeField] private bool DEBUGGING;
    [SerializeField] private bool DEBUGGINGERROR;
    [HideInInspector] public ItemWeapon scriptableObject;
    [SerializeField] private Inventory Inventory; 
    private float playerx;
    private bool delayActive = false;
    private bool canAttack;
    [HideInInspector]public string CurrentlyActiveWeapon;
    private GameObject CurrentlyActiveGameObject;
    private Animator AnimationP;
    private GameObject[] WeaponArray;
    private void Awake()
    {
        check();
        playerx = transform.localScale.x;
    }
    void Update()
    {
        CurrentlyActiveGameObject = Inventory.ActiveWeaponG;
        scriptableObject = WIM.Get(CurrentlyActiveWeapon);
        AnimationP = CurrentlyActiveGameObject.GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if(transform.localScale.x != playerx) //proverava da li se rotacija playera promenila i ako jeste onda rotira bulletAim
        {
            playerx = transform.localScale.x;
            Debuging("player trazi rotaciju");
            if(scriptableObject.hasBullet is true)
            {
            Rotate(CurrentlyActiveGameObject.transform.Find("BulletAim").gameObject);//namesti da se ocita objekat koji treba da se rotira
            }
        }
        check();
    }
    GameObject FindW (string ActiveWeapon)
    {
       WeaponArray = GameObject.FindGameObjectsWithTag("Weapon");
       foreach(GameObject x in WeaponArray)
       {
           if(x.name == CurrentlyActiveWeapon)
           {
               return x;
           }
       }
       return null;
    }
    void Attack() //ako je canAttack true onda pokreni animaciju i pokreni udarac
    {
        if(canAttack == true)
        {
            AnimationP.SetBool("MouseClick", true);
            switch (scriptableObject.hasBullet) 
            {
                case true:
                    InstantiateBullet(scriptableObject.Bullet, CurrentlyActiveGameObject.transform.Find("BulletAim"));
                    SetInputDelay(scriptableObject.speedOfShooting);
                break;
                case false:
                    //udari macem
                break;
            }//ako je hasbullet true pucace bullet a ako nije onda ce udariti macem
        }
        else
        {
            Debuging("CanAttack is false");
        }
    }
    void check() //proverava da li je weapon u ruci i ako jeste onda proverava koj je u pitanju i postavlja da moze da udara
    {
        Debug.Log("function called");
        if(Aim.transform.childCount > 0)
        { 
            Debug.Log("veci od nule xd");
            for (int i = 0; i < Aim.transform.childCount; i++)
            {
                Debug.Log("trying");
                if (Aim.transform.GetChild(i).gameObject.activeSelf == true) //ako je neki weapon aktivan pribelezi koji je i ukulji canAttack
                {
                    Debug.Log("nesto je aktivno");
                    CurrentlyActiveWeapon = Aim.transform.GetChild(i).name;
                    
                    if (delayActive != true) //ako delay nije trenutno aktivan onda je canattack true
                    {
                        canAttack = true;
                    }
                }
                else
                {
                    Debug.Log("else");
                    if(ifNothingsActive(Aim) == true)
                    {
                        Debug.Log("nothings active true");
                        Debuging("not active");
                        CurrentlyActiveWeapon = "None";
                        canAttack = false;
                    }
                }
            }
        }
        else 
        {
            Debug.Log("Nema dece xd");
            CurrentlyActiveWeapon = "None";
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
    void AfterShot(Rigidbody2D RB,Transform ObjectToDestroy)
    {
        RB.velocity = ObjectToDestroy.right * scriptableObject.bulletSpeed;
        Destroy(ObjectToDestroy.gameObject, scriptableObject.DestroyAfter);
    }
    private void InstantiateBullet(GameObject Bullet,Transform BulletAim)
    {
        var clonebullet = Instantiate(Bullet.transform, BulletAim.position, BulletAim.rotation);
        AfterShot(clonebullet.GetComponent<Rigidbody2D>(),clonebullet);
    }
    void SetInputDelay(float Delay) //primeni delay
    {
        canAttack = false;
        Invoke("ClearInputDelay", Delay);
        Debuging("delay se aktivirao");
        delayActive = true;
    }

    void ClearInputDelay()//primenjen delay posle izvesnog vremena menja funkciju
    {
        canAttack = true;
        delayActive = false;
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
