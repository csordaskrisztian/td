using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    
    public void Levelselect()
    {
        SceneManager.LoadScene("level_select");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Upgrades()
    {
        SceneManager.LoadScene("upgrade");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("bruh");
    }
}
