using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    [SerializeField]
    GameSetUp gameSetUp;
    [SerializeField]
    AsteroidSpawner asteroidSpawner;
    [SerializeField]
    Event onLevelStart;
    private List<LevelData> levelsetupList;
    public int numberOfEnemy;
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

    public void StartGenericLevel()
    {
        int amount = UnityEngine.Random.Range(0,10);
        numberOfEnemy = 3*amount+5+ amount / 9;
        asteroidSpawner.Spawn(amount+2, amount+1, amount+2, amount/9);
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
