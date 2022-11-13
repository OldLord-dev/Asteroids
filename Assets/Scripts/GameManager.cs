using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int playerHealth = 3;
    public static float score = 0;
    public static String playerName = "";
    public static int level = 0;
    public Texture2D cursorTexture;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Game Over Screen", LoadSceneMode.Single);
    }


}