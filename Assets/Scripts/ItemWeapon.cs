using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class ItemWeapon : ScriptableObject
{

    [Header("Basic Data")]
    public float id = 0;
    public new string name = "None";
    [Multiline]public string description = "None";
    public Sprite icon = null;

    [Header("Weapon oriented data")]
    [Range(0, 100f)]public float damage = 0;
    public GameObject weapon = null;

    [Header("Gun")]
    public bool hasBullet = false;
    public bool holdToShot = false;
    public GameObject Bullet = null;
    public GameObject BulletAim = null;
    [Range(1,200f)]public float bulletSpeed = 0;
    [Range(0.1f,10)]public float DestroyAfter = 0;
    [Range(0,2f)]public float speedOfShooting = 0;

    [Header("Sword")]
    public float SpeedOfAttack = 0;
}
