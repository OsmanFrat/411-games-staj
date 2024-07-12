using UnityEngine;

public class GoldenWatermelon : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int goldenWatermelon = 500;

    [SerializeField] private const string PLAYER_TAG = "Blade";
    [SerializeField] private GameObject GoldenSlicedWatermelonPrefab;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startForce = 15f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruits = Instantiate(GoldenSlicedWatermelonPrefab, transform.position, rotation);

            gameManager.AddScore(goldenWatermelon);

            Destroy(slicedFruits, 3f);
            Destroy(gameObject);
        }
    }
}
