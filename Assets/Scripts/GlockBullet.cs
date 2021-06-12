using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlockBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private ItemWeapon Glock;
    void Start()
    {
        Glock.Shot(RB);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
