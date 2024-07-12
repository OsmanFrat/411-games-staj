using UnityEngine;

public class FruitDetector : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoldenWatermelon"))
        {
            Debug.Log("GoldenWatermelon detected!");
            if (!gameManager.gameOver)
            {
                gameManager.playerHealth--;
            }

        }
    }
}
