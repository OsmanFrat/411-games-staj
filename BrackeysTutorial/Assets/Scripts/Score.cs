using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text scoreText;

    private void Update()
    {
        // Getting score without floats and setting to the score text
        scoreText.text = player.position.x.ToString("0");
    }
}
