using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject currentTarget = null;
    public float range;
    public Transform turretrotate;
    public Transform gunrotate;

    fast_shooting Fast_Shooting;

    void Start()
    {
        Fast_Shooting = GetComponent<fast_shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentTarget)
        {
            targets = GameObject.FindGameObjectsWithTag("enemy");
            float mindist = 10000;
            for (int i = 0; i < targets.Length; i++)
            {

                float distance = Vector3.Distance(transform.position, targets[i].transform.position);
                if (distance < mindist && distance < range)
                {
                    currentTarget = targets[i];
                    mindist = distance;

                    Fast_Shooting.TargetAcquire(currentTarget);
                    
                }
            }
       
        }

        if (currentTarget)
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            //transform.forward = targetDirection;
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            Vector3 r = Quaternion.Lerp(turretrotate.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
            turretrotate.rotation = Quaternion.Euler(0f, r.y, 0f);
            gunrotate.rotation = Quaternion.Euler(lookRotation.eulerAngles.x, r.y, 0f);
        }

    }
}
