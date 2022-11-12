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
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            GameObject a = Pool.singleton.Get("AsteroidBig");
            if (a != null)
            {
                SetRandomSpawnPoint(a);
                a.SetActive(true);
            }

            GameObject b = Pool.singleton.Get("AsteroidMedium");
            if (b != null)
            {
                SetRandomSpawnPoint(b);
                b.SetActive(true);
            }

            GameObject c = Pool.singleton.Get("AsteroidSmall");
            if (c != null)
            {
                SetRandomSpawnPoint(c);
                c.SetActive(true);
            }
        }
    }
}
