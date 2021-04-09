using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast_shooting : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    GameObject target;
    public float timer;
    public float dmg;
    //int t = 0;

    void Start()
    {

    }


    void Update()
    {
        if (target)
        {
            timer += Time.deltaTime;
            if (timer > 0.25)
            {
                shoot();
                timer = 0;
                /*t++;
                if (t == 4) t = 0;*/
            }
        }
        
    }

    public void TargetAcquire(GameObject t)
    {
        target = t;
    }
    void shoot()
    {
        muzzleFlash.Play();
        target.GetComponent<enemy>().health -= dmg;
    }
}
