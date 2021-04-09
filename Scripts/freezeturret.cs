using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeturret : MonoBehaviour
{
    public GameObject currentTarget = null;
    public GameObject[] targets;
    public float range;
    public float distance;
    public static int cost = 6;

    private void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < targets.Length; i++)
        {

            distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if (distance < range)
            {
                targets[i].GetComponent<enemy>().slowed = true;
            }
            else
            {
                targets[i].GetComponent<enemy>().slowed = false;
            }
        }
    }

}
