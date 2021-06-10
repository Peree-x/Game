using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //scena koja se bira kada se pritisne dugme "play"
    public void PlayGame ()
        {
            SceneManager.LoadScene("SampleScene");
        }
    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
