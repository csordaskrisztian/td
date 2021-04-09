using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class turretbase : MonoBehaviour
{
    public bool alreadybuilt = false;
    public bool buildMenuActive = false;
    public Color colorToChange;
    public Color colorDefault;
    public int costofbuild;
    public GameObject turret;
    public GameObject highlight;

    public new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        colorDefault = renderer.material.color;
    }

    void OnMouseDown()
    {
        if (!game.gameIsPaused && !EventSystem.current.IsPointerOverGameObject())
        {
            GetComponentInParent<game>().BuildMenu(gameObject);
            //renderer.material.SetColor("_BaseColor", colorToChange);
            buildMenuActive = true;
        }
    }

    private void OnMouseEnter()
    {
        if (!game.gameIsPaused && !alreadybuilt)
        {
            //renderer.material.SetColor("_BaseColor", colorToChange);
            highlight.SetActive(true);

        }
    }

    private void OnMouseExit()
    {
        if (buildMenuActive == false)
        {
            //renderer.material.SetColor("_BaseColor", colorDefault);
            highlight.SetActive(false);
        }

    }

    public void BuildMenuCanceled()
    {
        buildMenuActive = false;
        //renderer.material.SetColor("_BaseColor", colorDefault);
        highlight.SetActive(false);
    }
}
