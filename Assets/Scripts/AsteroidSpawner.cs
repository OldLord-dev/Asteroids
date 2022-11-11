using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private Vector3 screenXYmax;
    private Vector3 screenX0Ymax;
    private Vector3 screenXmaxY0;
    private Vector3 screenXY0;
    // Use this for initialization
    void Start()
    {
        //00//
       // M//0
       // 0M
     //   MM
        screenXYmax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenX0Ymax = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenXmaxY0 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        screenXY0 = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    private void SetRandomSpawnPoint(GameObject a)
    {
        int randomScreenEdge = Random.Range(0, 4);
        switch (randomScreenEdge)
        {
            case 0:
                {
                    a.transform.position = new Vector3(Random.Range(-screenXY0.x, screenXY0.x), screenX0Ymax.y, 0);
                    break;
                }

            case 1:
                {
                    a.transform.position = new Vector3(Random.Range(-screenXY0.x, screenXY0.x), -screenX0Ymax.y, 0);
                    break;
                }

            case 2:
                {
                    a.transform.position = new Vector3(screenXY0.x, Random.Range(-screenX0Ymax.y, screenX0Ymax.y), 0);
                    break;
                }

            case 3:
                {
                    a.transform.position = new Vector3(-screenXY0.x, Random.Range(-screenX0Ymax.y, screenX0Ymax.y), 0);
                    break;
                }
        }
    }

    // Update is called once per frame
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
