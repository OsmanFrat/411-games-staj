using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool playerDead = false;
    public bool respawn = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && respawn)
        {
            playerDead = true;
        }
    }
}
