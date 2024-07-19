using UnityEngine;
using DG.Tweening;

public class BouncePrefab : MonoBehaviour
{
    bool isBouncing = false;
    Vector3 originalScale;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce();
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
