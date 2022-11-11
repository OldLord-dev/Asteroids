using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> asteroids = new List<Sprite>();
    [SerializeField]
    private float asteroidScale;
    [SerializeField]
    private float asteroidSpeed = 3f;
    [SerializeField]
    private float asteroidPoints = 100;

    private SpriteRenderer spriteRenderer;
    private float randomVelocity;
    private float randomAngle;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale *= asteroidScale;
    }

    private void OnEnable()
    {
        if(asteroids.Count > 0 && spriteRenderer)
        {
            spriteRenderer.sprite = asteroids[Random.Range(0, asteroids.Count)];
        }
            randomVelocity = Random.Range(1, 2);
            randomAngle = Random.Range(1, 2);
            transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0,0,1)) * transform.rotation;


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(randomVelocity * asteroidSpeed * Time.deltaTime, randomAngle * asteroidSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            GameManager.score += asteroidPoints;
            this.gameObject.SetActive(false);
        }
    }


}
