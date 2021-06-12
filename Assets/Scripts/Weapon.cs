using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField][InspectorName("GlockData")] private ItemWeapon Glock;
    [SerializeField] private GameObject Aim;
    [SerializeField] private bool DEBUGGING;
    [SerializeField] private bool DEBUGGINGERROR;
    private float playerx;
    private bool delayActive = false;
    private ItemWeapon scriptableObject;
    private bool canAttack;
    private void Awake()
    {
        check();
        playerx = transform.localScale.x;
    }
    void Update()
    {
        check();
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
            Rotate(scriptableObject.BulletAim.gameObject);//namesti da se ocita objekat koji treba da se rotira
            }
        }
        Debug.Log(""+Glock.name);
    }
    void Attack() //ako je canAttack true onda pokreni animaciju i pokreni udarac
    {
        if(canAttack == true)
        {
            scriptableObject.weapon.GetComponent<Animator>().SetBool("MouseClick", true);
            switch (scriptableObject.hasBullet) 
            {
                case true:
                    InstantiateBullet(scriptableObject.Bullet);
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
        for (int i = 0; i < Aim.transform.childCount; i++)
        {
            if (Aim.transform.GetChild(i).gameObject.activeSelf == true) //ako je neki weapon aktivan pribelezi koji je i ukulji canAttack
            {
                scriptableObject = Resources.Load<ItemWeapon>(Aim.transform.GetChild(i).name);
                
                if (delayActive != true) //ako delay nije trenutno aktivan onda je canattack true
                {
                    canAttack = true;
                }
                break;
            }
            else //ovo pravi bugove ako ih ima vise smisli bolji nacin
            {
                canAttack = false;
            }
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
    private void InstantiateBullet(GameObject Bullet)
    {
        Instantiate(Bullet.transform, scriptableObject.BulletAim.transform.position, scriptableObject.BulletAim.transform.rotation);
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
