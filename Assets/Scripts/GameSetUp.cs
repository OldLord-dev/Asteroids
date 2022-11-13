using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public  class GameSetUp : MonoBehaviour
{
    [Header("Path to the level files: Assets\\ScriptableObject\\Levels")]
    public List<LevelData> levels;
    public static GameSetUp Instance { get; private set; }

    private void Awake()
    {
       if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
    }
}
