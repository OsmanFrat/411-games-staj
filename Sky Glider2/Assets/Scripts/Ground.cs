using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool playerDead = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDead = true;
            //collision.gameObject.GetComponent<RocketManController>().enabled = false;
        }
    }
}
