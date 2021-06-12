using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem {
    public int id;
    public string name;
    public string description;
    public Sprite icon;

    public WeaponItem(int id)
    {

    }
}
    public class GunItem
    {
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public float damage;
    public GameObject weapon;
    public bool hasBullet;
    public bool holdToShot;
    public GameObject Bullet;
    public GameObject BulletAim;
    public float bulletSpeed;
    public float DestroyAfter;
    public float speedOfShooting;
        public GunItem(
        int id,
        string name,
        string description,
        Sprite icon,
        float damage,
        GameObject weapon,
        bool hasBullet,
        bool holdToShot,
        GameObject Bullet,
        GameObject BulletAim,
        float bulletSpeed,
        float DestroyAfter,
        float speedOfShooting
        )
        {
            this.id=id;
            this.name=name;
            this.description=description;
            this.icon=icon;
            this.damage=damage;
            this.weapon=weapon;
            this.hasBullet=hasBullet;
            this.holdToShot=holdToShot;
            this.Bullet=Bullet;
            this.BulletAim=BulletAim;
            this.bulletSpeed=bulletSpeed;
            this.DestroyAfter=DestroyAfter;
            this.speedOfShooting=speedOfShooting;
        }
        public GunItem(GunItem gunitem)
        {
            this.id=gunitem.id;
            this.name=gunitem.name;
            this.description=gunitem.description;
            this.icon=gunitem.icon;
            this.damage=gunitem.damage;
            this.weapon=gunitem.weapon;
            this.hasBullet=gunitem.hasBullet;
            this.holdToShot=gunitem.holdToShot;
            this.Bullet=gunitem.Bullet;
            this.BulletAim=gunitem.BulletAim;
            this.bulletSpeed=gunitem.bulletSpeed;
            this.DestroyAfter=gunitem.DestroyAfter;
            this.speedOfShooting=gunitem.speedOfShooting;
        }
//copy paste this !!!!!!!!!
    //int id,
    //string name,
    //string description,
    //Sprite icon,
    //float damage,
    //GameObject weapon,
    //bool hasBullet,
    //bool holdToShot,
    //GameObject Bullet,
    //GameObject BulletAim,
    //float bulletSpeed,
    //float DestroyAfter,
    //float speedOfShooting
    }
    public class SwordItem
    {
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public float damage;
    public GameObject weapon;
    public float SpeedOfAttack;
    public SwordItem()
    {

    }
    }
