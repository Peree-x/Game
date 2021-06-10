using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class gun : MonoBehaviour
{
    private Transform aimTransform;
    private void Awake()
    {
        aimTransform.Find("Aim");
    }
    private void Update()
    {
        FindMouse();
        Shoot();
    }
    private void FindMouse ()
    {
        Vector3 MousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 AimDirection = (MousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
    private void Shoot()
    {

    }
}
