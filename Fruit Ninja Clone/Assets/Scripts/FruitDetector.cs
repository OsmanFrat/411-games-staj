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
            GoldenWatermelon goldenWatermelon = collision.gameObject.GetComponent<GoldenWatermelon>();
            
            if (goldenWatermelon != null && !goldenWatermelon.isSliced)
            {
                Debug.Log("GoldenWatermelon out of bounds!");
                if (!gameManager.gameOver)
                {
                    gameManager.playerHealth--;
                }
            }
        }
    }
}
