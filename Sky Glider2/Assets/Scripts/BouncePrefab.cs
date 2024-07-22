using UnityEngine;
using DG.Tweening;

public class BouncePrefab : MonoBehaviour
{
    [SerializeField] private Ground ground;
    private bool isBouncing = false;
    private Vector3 originalScale;
    public float yForce = 20f;
    public float zforce = 20f;
 
    public bool doubleForce = false;
    void Start()
    {
        ground = GameObject.Find("Ground").GetComponent<Ground>();
        //Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!ground.playerDead)
            {
                Bounce();

                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if (doubleForce)
                {
                    rb.AddForce(0f, yForce * 2, zforce * 2, ForceMode.Impulse);
                }
                else
                {
                    rb.AddForce(0f, yForce, zforce, ForceMode.Impulse);
                }
            }
        }
    }

    public void Bounce()
    {
        originalScale = transform.localScale;

        if (!isBouncing)
        {
            isBouncing = true;
            transform.localScale = originalScale * 0.8f;


            transform.DOScale(new Vector3(originalScale.x * 1.2f, originalScale.y * 1.7f, originalScale.z), 0.3f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => {
                    transform.DOScale(originalScale, 0.3f).SetEase(Ease.InQuad);
                    isBouncing = false;
                });
        }
    }
}
