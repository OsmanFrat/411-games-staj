using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public bool gameOver = false;
    public GameObject gameOverPanel;
    public FruitSpawner fruitSpawner;
    public GameObject blade;

    private void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);   
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
