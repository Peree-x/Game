using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;

    public void SettingsIn()
    {
        main.SetActive(false);
        settings.SetActive(true);
    }
    public void SettingsOut()
    {
        main.SetActive(true);
        settings.SetActive(false);
    }
}
