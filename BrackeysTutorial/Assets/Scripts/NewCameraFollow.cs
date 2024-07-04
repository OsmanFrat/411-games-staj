using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        // 
        offset = transform.position - player.position;
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
