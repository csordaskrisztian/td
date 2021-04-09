using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_turret : MonoBehaviour
{
    public GameObject currentTarget = null;
    public GameObject[] targets;
    public float range;
    public Transform turretrotate;
    public ParticleSystem water;
    public float timer = 1;
    public GameObject barrelend;
    public LineRenderer lineRenderer;
    public static int cost = 8;

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
                if (distance < mindist && distance < range)
                {
                    currentTarget = targets[i];
                    mindist = distance;
                }
            }

        }
        if (currentTarget)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (distance > range)
            {
                currentTarget = null;
            }
            else { TrackandShoot(); }
            
        }

    }
    public void TrackandShoot()
    {
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        Vector3 r = Quaternion.Lerp(turretrotate.rotation, lookRotation, Time.deltaTime * 20).eulerAngles;
        turretrotate.rotation = Quaternion.Euler(0f, r.y, 0f);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, barrelend.transform.position);
        lineRenderer.SetPosition(1, currentTarget.transform.position);

        currentTarget.GetComponent<enemy>().health -= 0.5f;


    }
}
