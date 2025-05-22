using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScrore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject settingsScreen;
    public GameObject menuScreen;
    public BirdScript bird;

    private void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        Time.timeScale = 0;
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScrore += 1;
        scoreText.text = playerScrore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void SettingsScreen()
    {
        menuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void SettingsBack()
    {
        if (bird.birdIsAlive)   // In game
        {
            settingsScreen.SetActive(false);
            Time.timeScale = 1;
        } else                  // In main menu
        {
            settingsScreen.SetActive(false);
            menuScreen.SetActive(true);
        }
        
    }

    public void StartGame()
    {
        scoreText.text = "0";
        Time.timeScale = 1;
        menuScreen.SetActive(false);
        bird.birdIsAlive = true;
        bird.startText.SetActive(true);
    }
}
