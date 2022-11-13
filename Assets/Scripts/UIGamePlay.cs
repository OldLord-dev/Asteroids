using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour
{
    public Text scoreText,levelNumber;
    public List<GameObject> playerHealth;
    public void OnAsteroidDestroyed()
    {
        scoreText.text = GameManager.score.ToString();
    }
    public void OnLevelStart()
    {
        levelNumber.text = GameManager.level.ToString();
    }
    public void OnShipDamage()
    {
        playerHealth[0].SetActive(false);
        playerHealth.RemoveAt(0);   
    }
}
