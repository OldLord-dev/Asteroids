using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField]
    public Event onAsteroidDestroyed;
    [SerializeField]
    private AsteroidData enemyShipData;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 randomDirection;
    private Transform playerTransform;
    float fireRate = 1.5f;
    float nextFire = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale *= enemyShipData.AsteroidScale;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        if(enemyShipData.AsteroidsSpriteSet.Sprites.Count > 0 && spriteRenderer)
        {
            spriteRenderer.sprite = enemyShipData.AsteroidsSpriteSet.Sprites[Random.Range(0, enemyShipData.AsteroidsSpriteSet.Sprites.Count)];
        }
        int leftOrRight= Random.Range(0, 2);

        if (leftOrRight==0)
            randomDirection = Vector2.left;
        else
            randomDirection = Vector2.right;

        randomDirection *= enemyShipData.AsteroidSpeed;

    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = randomDirection;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerTransform.position - transform.position);

        if (Time.time > nextFire)
        {
            if (Random.Range(0, 100) < 2) { 
            nextFire = Time.time + fireRate;
            EnemyFire();
            }
        }
    }
    private void EnemyFire()
    {
        GameObject bullet = Pool.singleton.Get("EnemyBullet");
        if (bullet != null)
        {
            bullet.transform.position = transform.localPosition;
            bullet.transform.rotation = transform.localRotation;
            bullet.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            GameManager.score += enemyShipData.AsteroidPoints;
            gameObject.SetActive(false);
        }
        else
            gameObject.SetActive(false);

        CancelInvoke();
        onAsteroidDestroyed.Occurred();
    }
}
