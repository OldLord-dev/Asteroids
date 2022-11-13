using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private UIGamePlay uiGamePlay;
    [SerializeField]
    private BoxCollider2D screenCollider;
    public Event onShipDestroyed;
    private Collider2D playerCollider;
    private void Start()
    {
        playerCollider = gameObject.GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.playerHealth > 0)
        {
            uiGamePlay.OnShipDamage();
            MoveToSafeLocation();
            GameManager.playerHealth--;
        }
        if (GameManager.playerHealth == 0)
            GameManager.GameOver();
    }

    private void MoveToSafeLocation()
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        bool found = false;
        Vector2 shipNewPosition = transform.position;
        Vector2 screenExtents = screenCollider.size / 2;
        screenExtents.x -= 2;
        screenExtents.y -= 2;
        float radius = 3f;
        float playershipRadius = playerCollider.bounds.extents.magnitude;
        while(found==false && radius > playershipRadius)
        { 
            shipNewPosition = new Vector2(Random.Range(-screenExtents.x, screenExtents.x), Random.Range(-screenExtents.y, screenExtents.y));
            if (Physics2D.OverlapCircle(shipNewPosition, radius, mask) == null)
                found = true;

                radius -= 0.05f;
        }
        if(found)
           transform.position = shipNewPosition;
    }
}
