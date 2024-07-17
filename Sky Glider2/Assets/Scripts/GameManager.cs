using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ground ground;


    private void Update()
    {
        if (ground.playerDead)
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
