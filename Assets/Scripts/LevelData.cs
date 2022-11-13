using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelData", menuName = "Level Data", order = 53)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int bigAsteroidAmount;
    [SerializeField]
    private int mediumAsteroidAmount;
    [SerializeField]
    private int smallAsteroidAmount;
    [SerializeField]
    private int enemyShipAmount;

    public int BigAsteroidAmount { get { return bigAsteroidAmount; } }
    public int MediumAsteroidAmount { get { return mediumAsteroidAmount; } }
    public int SmallAsteroidAmount { get { return smallAsteroidAmount; } }
    public int EnemyShipAmount { get { return enemyShipAmount; } }
}
