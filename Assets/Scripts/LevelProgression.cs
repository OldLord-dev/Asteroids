using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    [SerializeField]
    private GameSetUp gameSetUp;
    [SerializeField]
    private AsteroidSpawner asteroidSpawner;
    [SerializeField]
    private Event onLevelStart;
    private List<LevelData> levelsetupList;
    private int numberOfEnemy;
    int levelNumber = 0;
    void Start()
    {
        levelsetupList = gameSetUp.levels;
        GameManager.level = levelNumber + 1;
        onLevelStart.Occurred();
    }

    public void StartLevel()
    {
        numberOfEnemy = levelsetupList[levelNumber].EnemyShipAmount
            + levelsetupList[levelNumber].BigAsteroidAmount
            + levelsetupList[levelNumber].MediumAsteroidAmount
            + levelsetupList[levelNumber].SmallAsteroidAmount;
        asteroidSpawner.Spawn(levelsetupList[levelNumber].EnemyShipAmount, levelsetupList[levelNumber].BigAsteroidAmount,
            levelsetupList[levelNumber].MediumAsteroidAmount, levelsetupList[levelNumber].SmallAsteroidAmount);
    }

    public void StartGenericLevel()// For testing
    {
        int amount = UnityEngine.Random.Range(0,10);
        numberOfEnemy = 3*amount+5+ amount / 8;
        asteroidSpawner.Spawn(amount / 8, amount+1, amount+2, amount+2);
    }
    public void OnEnemyDestroyed()
    {
        numberOfEnemy--;
        if(numberOfEnemy == 0)
        {
            NextLevel();
        }
    }
    public void NextLevel()
    {
        if (levelNumber < levelsetupList.Count - 1)
        {
            levelNumber++;
            GameManager.level = levelNumber + 1;
            onLevelStart.Occurred();
            StartLevel();
        }
        else
        {
            levelNumber++;
            GameManager.level = levelNumber + 1;
            onLevelStart.Occurred();
            StartGenericLevel();
        }

    }
}
