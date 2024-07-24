using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ground ground;
    [SerializeField] private LaunchController launchController;

    public GameObject player;
    public TextMeshProUGUI score;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highestScore;
    public GameObject gameOverPanel;

    private float currentHighestZ;
    private float highScore;

    private void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        currentHighestZ = player.transform.position.z;

        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highestScore.text = "High Score: " + highScore.ToString("0");
    }

    private void Update()
    {
        if (ground.playerDead)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (launchController.playerThrown && !ground.playerDead)
        {
            float currentZ = player.transform.position.z;
            if (currentZ > currentHighestZ)
            {
                currentHighestZ = currentZ;
            }
            score.text = currentHighestZ.ToString("0");
            currentScore.text = "Score: " + currentHighestZ.ToString("0");

            if (currentHighestZ > highScore)
            {
                highScore = currentHighestZ;
                PlayerPrefs.SetFloat("HighScore", highScore);
                highestScore.text = "High Score: " + highScore.ToString("0");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ground.playerDead = false;
    }
}
