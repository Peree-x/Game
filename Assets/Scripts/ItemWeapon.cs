using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class ItemWeapon : ScriptableObject
{

    [Header("Basic Data")]
    public float id;
    public new string name;
    [Multiline]public string description;
    public Sprite icon;

    [Header("Weapon oriented data")]
    [Range(0, 100f)]public float damage;
    public GameObject weapon;

    [Header("Gun")]
    public bool hasBullet;
    public bool holdToShot;
    public GameObject Bullet;
    public GameObject BulletAim;
    [Range(1,200f)]public float bulletSpeed;
    [Range(0.1f,10)]public float DestroyAfter;
    [Range(0,2f)]public float speedOfShooting;

    [Header("Sword")]
    public float SpeedOfAttack;
    public void Shot(Rigidbody2D RB)
    {
        RB.velocity = Bullet.transform.right * bulletSpeed;
        Destroy(Bullet, DestroyAfter);
    }

}
