using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter()
    {
        gameManager.LevelComplete();
    }
}
