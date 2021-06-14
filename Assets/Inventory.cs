using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject ActiveWeaponG;
    public GameObject ActiveItemG;

    // Update is called once per frame
    void Update()
    {
        ActiveWeaponG = GameObject.FindWithTag("Weapon");
        ActiveItemG = GameObject.FindWithTag("Item");
    }
}
