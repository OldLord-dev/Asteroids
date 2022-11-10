using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> asteroids = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if(asteroids.Count > 0 && spriteRenderer)
        {
            spriteRenderer.sprite = asteroids[Random.Range(0, asteroids.Count)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
