using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private InputField submitedName;
    [SerializeField]
    private Text displayPlayerName;
    [SerializeField]
    private GameObject errorText;
    void Start()
    {
        errorText.SetActive(false);
    }

    public void SetPlayerName()
    {
        displayPlayerName.text = submitedName.text;
        GameManager.playerName = submitedName.text;
    }
    public void OnNewGameClick()
    {
        if (GameManager.playerName == "" || GameManager.playerName == null)
        {
            errorText.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void OnExitGameClick()
    {
        Application.Quit();
    }

}
