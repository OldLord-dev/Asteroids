using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text reacherLevel;
    void Start()
    {
        playerName.text = GameManager.playerName;
        score.text = GameManager.score.ToString();
        reacherLevel.text = GameManager.level.ToString();
    }

    public void OnClickStartAgain()
    {
        GameManager.score = 0;
        GameManager.playerHealth = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnClickMainmenu()
    {
        GameManager.score = 0;
        GameManager.playerHealth = 3;
        GameManager.playerName="";
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
