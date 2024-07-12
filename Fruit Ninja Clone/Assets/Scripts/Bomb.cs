using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public ParticleSystem bombEffect;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startForce = 12f;
    public AudioSource explosionSound;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blade"))
        {
            bombEffect.Play();
            explosionSound.Play();

            Destroy(gameObject, .35f);
            gameManager.GameOver();
        }
    }

}
