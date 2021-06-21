using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private GameObject Aim;
    [SerializeField] private GameObject glock;
    private void Awake()
    {
        Aim = GameObject.FindWithTag("Aim");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindWithTag("Weapon") == null)
        {
            var gun = Instantiate(glock,Aim.transform);
            gun.transform.name = gun.transform.name.Replace("(Clone)","").Trim();
        }
        else
        if(GameObject.FindWithTag("Weapon").name != "Glock")
        {
            var gun = Instantiate(glock,Aim.transform);
            gun.transform.name = gun.transform.name.Replace("(Clone)","").Trim();
        }
    }
}
