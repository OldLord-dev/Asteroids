using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private Vector3 upperRightCorner;
    void Start()
    {
        upperRightCorner = -Camera.main.ScreenToWorldPoint(Vector3.zero);
        upperRightCorner.x -= 1;
        upperRightCorner.y -= 1;
    }
    private void SetRandomSpawnPoint(GameObject a)
    {
        int randomScreenEdge = Random.Range(0, 4);
        switch (randomScreenEdge)
        {
            case 0://Top Game Edge
                {
                    a.transform.position = new Vector3(Random.Range(-upperRightCorner.x, upperRightCorner.x), upperRightCorner.y, 0);
                    break;
                }

            case 1://Bottom Game Edge
                {
                    a.transform.position = new Vector3(Random.Range(-upperRightCorner.x, upperRightCorner.x), -upperRightCorner.y, 0);
                    break;
                }

            case 2://Left Game Edge
                {
                    a.transform.position = new Vector3(-upperRightCorner.x, Random.Range(-upperRightCorner.y, upperRightCorner.y), 0);
                    break;
                }

            case 3://Right Game Edge
                {
                    a.transform.position = new Vector3(upperRightCorner.x, Random.Range(-upperRightCorner.y, upperRightCorner.y), 0);
                    break;
                }
        }
    }

    public void Spawn(int enemyShipAmount, int bigAsteroidAmount, int mediumAsteroidAmount, int smallAsteroidAmount)
    {
            for (int i = 0; i < bigAsteroidAmount; i++)
        {
            GameObject a = Pool.singleton.Get("AsteroidBig");
            if (a != null)
            {
                SetRandomSpawnPoint(a);
                a.SetActive(true);
            }
        }

        for (int i = 0; i < mediumAsteroidAmount; i++)
        {
            GameObject b = Pool.singleton.Get("AsteroidMedium");
            if (b != null)
            {
                SetRandomSpawnPoint(b);
                b.SetActive(true);
            }
        }

        for (int i = 0; i < smallAsteroidAmount; i++)
        {
            GameObject c = Pool.singleton.Get("AsteroidSmall");
            if (c != null)
            {
                SetRandomSpawnPoint(c);
                c.SetActive(true);
            }
        }

        for (int i = 0; i < enemyShipAmount; i++)
        {
            GameObject enemyShip = Pool.singleton.Get("EnemyShip");
            if (enemyShip != null)
            {
                SetRandomSpawnPoint(enemyShip);
                enemyShip.SetActive(true);
            }
        }

    }
}
