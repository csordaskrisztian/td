using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselect : MonoBehaviour
{
    public Button[] buttons;
    private void Start()
    {
        int currentlvl = PlayerPrefs.GetInt("currentlvl", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i+1 > currentlvl)
            {
                buttons[i].interactable = false;
            }
        }
    }
    public void LoadLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("currentlvl", 1);
        SceneManager.LoadScene("level_select");
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
