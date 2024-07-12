using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public Text scoreText;
    public int score;
    public bool gameOver = false;
    public GameObject gameOverPanel;
    public GameObject fruitSpawner;
    public GameObject bombSpawner;
    public GameObject goldenWatermelonSpawner;
    public GameObject blade;
    
    public GameObject healthBar3;
    public GameObject healthBar2;
    public GameObject healthBar1;
    public GameObject healthBar0;
    
    public int playerHealth = 3;

    private void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);

        fruitSpawner.SetActive(true);
        bombSpawner.SetActive(true);
        goldenWatermelonSpawner.SetActive(true);

        healthBar3.SetActive(true);
        healthBar2.SetActive(false);
        healthBar1.SetActive(false);
        healthBar0.SetActive(false);
    }

    private void Update()
    {
        HealthUI();
    }

    public void HealthUI()
    {
        switch (playerHealth)
        {
            case 3:
                healthBar3.SetActive(true);
                healthBar2.SetActive(false);
                healthBar1.SetActive(false);
                healthBar0.SetActive(false);
                break;
            case 2:
                healthBar3.SetActive(false);
                healthBar2.SetActive(true);
                healthBar1.SetActive(false);
                healthBar0.SetActive(false);
                break;
            case 1:
                healthBar3.SetActive(false);
                healthBar2.SetActive(false);
                healthBar1.SetActive(true);
                healthBar0.SetActive(false);
                break;
            case 0:
                healthBar3.SetActive(false);
                healthBar2.SetActive(false);
                healthBar1.SetActive(false);
                healthBar0.SetActive(true);

                GameOver();
                break;

            default:
                break;
        }
    }
    public void AddScore(int scorePoint)
    {
        score += scorePoint;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        blade.GetComponent<CircleCollider2D>().enabled = false;
        Time.timeScale = .5f;
        gameOver = true;
        gameOverPanel.SetActive(true);

        fruitSpawner.SetActive(false);
        bombSpawner.SetActive(false);
        goldenWatermelonSpawner.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
