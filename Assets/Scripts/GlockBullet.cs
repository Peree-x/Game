using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlockBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D RB;
    public float DestroyTimer;
    [SerializeField] private Glock glockS;
    void Start()
    {
        RB.velocity = transform.right * speed;
        Destroy(gameObject, DestroyTimer);
    }
    void Update()
    {
        DestroyTimer = glockS.DestroyAfter;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
