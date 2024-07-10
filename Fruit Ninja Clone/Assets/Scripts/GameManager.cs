using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public GameObject gameOverPanel;
    public FruitSpawner fruitSpawner;

    private void Start()
    {
        
        gameOverPanel.SetActive(false);   
    }

    public void AddScore(int scorePoint)
    {
        score += scorePoint;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        fruitSpawner.gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
