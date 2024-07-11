using UnityEngine;

public class ExitBomb : MonoBehaviour
{
    [SerializeField] private const string PLAYER_TAG = "Blade";
    public bool gameExit = false;
    public ParticleSystem bombEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        { 
            gameExit = true;
            bombEffect.Play();
            Destroy(gameObject, .2f);
        }
    }
}
