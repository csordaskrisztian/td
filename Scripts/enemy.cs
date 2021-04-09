using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float health;
    public List<GameObject> waypoint;
    private int i;
    public float enemy_speed;
    public float enemyDefaultSpeed;
    public bool wet;
    public bool frozen;
    public bool slowed = false;
    public bool canBeFrozen = true;
    public float frozenTimeRemaining = 3;
    public GameObject dieEffect;
    public GameObject modell;

    public new Renderer renderer;
    public Color colorDefault;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position == GetComponentInParent<spawner>().spawners[0].transform.position)
        {
            waypoint = waypoints.routestatic1;

        }
        else if (transform.position == GetComponentInParent<spawner>().spawners[1].transform.position)
        {
            waypoint = waypoints.routestatic2;

        }
        enemyDefaultSpeed = enemy_speed;
        renderer = modell.GetComponent<Renderer>();
        colorDefault = renderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(dieEffect, transform.position, transform.rotation);
            spawner.buildPoints++;
            Destroy(gameObject);
        }

        if (!slowed)
        {
            enemy_speed = enemyDefaultSpeed;
        }

        if (slowed)
        {
            enemy_speed = enemyDefaultSpeed / 2f;
            if (wet)
            {
                frozenTimeRemaining -= Time.deltaTime;
                enemy_speed = 0;

                renderer.material.SetColor("_BaseColor", Color.white);

                if (frozenTimeRemaining < 0)
                {
                    wet = false;
                    enemy_speed = enemyDefaultSpeed;
                    renderer.material.SetColor("_BaseColor", colorDefault);
                    frozenTimeRemaining = 3;
                }
            }
        }


    }
    private void FixedUpdate()
    {
        if (transform.position != waypoint[i].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[i].transform.position, Time.deltaTime * enemy_speed);
        }
        else if (transform.position == waypoint[waypoint.Count - 1].transform.position)
        {
            game.hp--;
            Destroy(gameObject);
        }
        else i++;
    }

    public void Iswet ()
    {
        wet = true;

    }


}

