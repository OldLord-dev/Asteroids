using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "asteroidData",menuName = "Asteroid Data",order = 50)]
public class AsteroidData : ScriptableObject
{
    [SerializeField]
    private SpriteSet asteroidsSpriteSet;
    [SerializeField]
    private float asteroidScale;
    [SerializeField]
    private float asteroidSpeed;
    [SerializeField]
    private float asteroidPoints;

    public float AsteroidScale { get { return asteroidScale; } }
    public float AsteroidSpeed { get { return asteroidSpeed; } }
    public float AsteroidPoints { get { return asteroidPoints; } }
    public SpriteSet AsteroidsSpriteSet { get { return asteroidsSpriteSet; } }
}
