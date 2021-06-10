using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGlock : MonoBehaviour
{
    public Animator glock;
    void ended()
    {
        glock.SetBool("MouseClick", false);
    }
}
