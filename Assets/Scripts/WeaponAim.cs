using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WeaponAim : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject spawnGameObject;
    public Transform BulletAim;
    public float inputDelay = 1f; //podesavanje kasnjenja
    bool CanShoot = true;
    public Animator glock;
    private void Awake()
    {
        aimTransform = transform.Find("Aim"); //nadji gameobject aim
    }

    private void Update()
    {
        check();
        FindMouse(); //pronadji mis na ekranu
        Shoot(); // pucaj mico
    }
    private void FindMouse() //neka veoma kul matematika koja prvo nalazi poziciju misa na ekranu pretvara je u poziciju u igrici pa tako racuna ugao pod kojim gleda
    {
        Vector3 MousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 AimDirection = (MousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void Shoot() //ovaj deo na dole samo pravi delay izmedju pucanja i sledeceg pucanja da ne mozes da spamujes
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanShoot is true) //ako mozes da pucas onda pucaj
            {
                Debug.Log("Button Pressed");
                SetInputDelay();
                glock.SetBool("MouseClick", true);
                Instantiate(spawnGameObject, BulletAim.position, BulletAim.rotation);

            }
            else
            {
                Debug.Log("Button Pressed but blocked by input delay");
            }
        }
    }
    void SetInputDelay()
    {
        CanShoot = false;
        Invoke("ClearInputDelay", inputDelay);
    }

    void ClearInputDelay()
    {
        CanShoot = true;
    }
    void check() // proveri dali je u ipotrebi
    {
        if (GetComponent<Animate>().TypeOfWeapon != "Pistol")
        {

            CanShoot = false;
        }
    }

}
