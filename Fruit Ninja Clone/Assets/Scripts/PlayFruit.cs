using UnityEngine;

public class PlayFruit : MonoBehaviour
{
    [SerializeField] private const string PLAYER_TAG = "Blade";
    public GameObject fruitSlicedPrefab;
    public bool gameStarted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruits = Instantiate(fruitSlicedPrefab, transform.position, rotation);

            gameStarted = true;

            Destroy(slicedFruits, 3f);
            Destroy(gameObject);
        }
    }


}