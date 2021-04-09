using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercanon : MonoBehaviour
{
    public GameObject currentTarget = null;
    public GameObject[] targets;
    public float range;
    public Transform turretrotate;
    public Transform gunrotate;
    public ParticleSystem water;
    public float timer = 1;
    public GameObject barrelend;
    public LineRenderer lineRenderer;
    public static int cost = 8;
    public Texture[] tex;

    public int n = 0;


    // Update is called once per frame
    void Update()
    {

        if (!currentTarget)
        {
            lineRenderer.enabled = false;
            targets = GameObject.FindGameObjectsWithTag("enemy");
            float mindist = 10000;
            for (int i = 0; i < targets.Length; i++)
            {

                float distance = Vector3.Distance(transform.position, targets[i].transform.position);
                if (distance < mindist && distance < range && !targets[i].GetComponent<enemy>().wet)
                {
                    currentTarget = targets[i];
                    mindist = distance;
                    Invoke("ApplyWet", 1f);

                }
            }

        }
        if (currentTarget)
        {
            TrackandShoot();
            if (timer > 1f / 10f)
            {
                n++;
                if (n == tex.Length)
                {
                    n = 0;
                }
                lineRenderer.material.SetTexture("_MainTex", tex[n]);

                timer = 0f;
            }
        }
        
        timer += Time.deltaTime;

    }

   public void ApplyWet()
    {
        if (currentTarget)
        {
            currentTarget.GetComponent<enemy>().Iswet();
            currentTarget = null;
        }
        
    }

    public void TrackandShoot()
    {
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        Vector3 r = Quaternion.Lerp(turretrotate.rotation, lookRotation, Time.deltaTime * 20).eulerAngles;
        turretrotate.rotation = Quaternion.Euler(0f, r.y, 0f);
        gunrotate.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, r.y, 0f);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, barrelend.transform.position);
        lineRenderer.SetPosition(1, currentTarget.transform.position);

    }
}
