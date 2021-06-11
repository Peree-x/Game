using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Glock : MonoBehaviour
{
    [Range(0, 100f)]public float damage = 20f;
    [Range(0,2f)]public float speedOfShooting = 0.3f;
    public bool holdToShot;
    public bool hasBullet;
    public GameObject Bullet;
    [Range(1,200f)]public float bulletSpeed = 20f;
    [Range(0.1f,10)]public float DestroyAfter = 5f;
    [SerializeField] private GlockBullet GBS;

    void start()
    {
        GBS.speed = bulletSpeed;
        GBS.DestroyTimer = DestroyAfter;
    }
    void Update()
    {
        GBS.speed = bulletSpeed;
        GBS.DestroyTimer = DestroyAfter;
        Debug.Log(GBS.DestroyTimer);
    }
    public void InstantiateBullet(Transform BulletAim)
    {
        Debug.Log(Bullet);
        Debug.Log(BulletAim.position);
        Debug.Log(BulletAim.rotation);
        Instantiate(Bullet, BulletAim.position, BulletAim.rotation);
    }
}

