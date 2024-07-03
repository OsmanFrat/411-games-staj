using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    private const string obstacleTag = "Obstacle";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == obstacleTag)
        {
            Debug.Log("We hit an obstacle!");
            playerMovement.enabled = false;
        }
    }
}
