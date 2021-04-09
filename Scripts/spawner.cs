using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class spawner : MonoBehaviour
{
    private float countdown = 3f;
    public float timebetweenwaves;
    public GameObject enemyprefab1;
    public GameObject enemyprefab2;
    public GameObject enemyprefab3;
    public Transform[] spawners;
    public static int buildPoints = 8;
    public int numberOfEnemy1;
    public int numberOfEnemy2;
    public int numberOfEnemy3;
    public List<GameObject> enemylist;
    public int n = 0;

    private void Start()
    {
        for (int i = 0; i < numberOfEnemy1; i++)
        {
            enemylist.Add(enemyprefab1);
        }
        for (int i = 0; i < numberOfEnemy2; i++)
        {
            enemylist.Add(enemyprefab2);
        }
        for (int i = 0; i < numberOfEnemy3; i++)
        {
            enemylist.Add(enemyprefab3);
        }
        var shuffled = enemylist.OrderBy(x => Guid.NewGuid()).ToList();
        enemylist = shuffled;

        buildPoints = 8;
    }


    void Update()
    {
        if (countdown <= 0f && n < enemylist.Count)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                spawnenemy(spawners[i], enemylist[n]);
            }

            countdown = timebetweenwaves;
            n++;
        }
        countdown -= Time.deltaTime;
        if (n >= enemylist.Count )
        {
            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("enemy");
            if (gameObjects.Length == 0)
            {
                game.gameWon = true;
            }
        }
    }

    void spawnenemy(Transform s, GameObject enemy)
    {
        Instantiate(enemy, s.position, s.rotation,transform);
    }
}
