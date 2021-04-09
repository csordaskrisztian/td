using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electric_turret : MonoBehaviour
{
    public List<GameObject> currentTarget;
    public List<LineRenderer> lrList;
    public int numberofTargets;
    public GameObject[] targets;
    public float range;
    public float distance;
    public LineRenderer lineRenderer;
    public Texture[] tex;
    public float timer;
    public int n = 0;
    public Transform effectOrigin;
    public static int cost = 10;

    private void Start()
    {
        lrList.Add(Instantiate(lineRenderer, transform.position, transform.rotation));
        lrList.Add(Instantiate(lineRenderer, transform.position, transform.rotation));
        lrList.Add(Instantiate(lineRenderer, transform.position, transform.rotation));
    }

    private void Update()
    {
        currentTarget.Clear();
        targets = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < targets.Length; i++)
        {

            distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if (distance < range && !currentTarget.Contains(targets[i]) && currentTarget.Count < numberofTargets)
            {
                currentTarget.Add(targets[i]);
            }
            else if (distance> range && currentTarget.Contains(targets[i]))
            {
                currentTarget.Remove(targets[i]);
            }

        }
        if (currentTarget.Count == 0)
        {
            lrList[0].enabled = false;
        }

        if (currentTarget.Count > 0)
        {

            for (int i = 0; i < lrList.Count; i++)
            {
                if (i+1 > currentTarget.Count)
                {
                    lrList[i].enabled = false;
                }
                else
                {
                    if (timer > 1f / 30f)
                    {
                        n++;
                        if (n == tex.Length)
                        {
                            n = 0;
                        }
                        lrList[0].material.SetTexture("_MainTex", tex[n]);
                        lrList[1].material.SetTexture("_MainTex", tex[n]);
                        lrList[2].material.SetTexture("_MainTex", tex[n]);
                        timer = 0f;
                    }
                    lrList[i].enabled = true;
                    lrList[i].SetPosition(0, effectOrigin.position);
                    lrList[i].SetPosition(1, currentTarget[i].transform.position);
                    if (!game.gameIsPaused)
                    {
                        currentTarget[i].GetComponent<enemy>().health -= 0.2f;
                    }
                    
                }
            }
        }

        timer += Time.deltaTime;

    }

}
