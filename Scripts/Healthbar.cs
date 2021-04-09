using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthbar;
    private float currenthealth;
    private float defaulthealth;
    // Start is called before the first frame update
    void Start()
    {
        defaulthealth = GetComponentInParent<enemy>().health;
        //healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currenthealth = GetComponentInParent<enemy>().health;
        healthbar.fillAmount = currenthealth / defaulthealth;

    }
}
