using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public Vector3 rotationSpeed = new Vector3(50, 0, 0);
    public bool ballLaunched = false;

    public void LaunchBall(float pullAmount)
    {
        ballLaunched = true;
        transform.parent = null;
        rb.isKinematic = false;

        // Calculate force based on pullAmount
        float forceMultiplier = 50f; // Adjust this multiplier as needed
        float xForce = pullAmount * forceMultiplier; // Calculate force in x-axis direction
        Vector3 launchForce = new Vector3(xForce, 15f, 0f); // Apply force along the x and y axes
        rb.AddForce(launchForce, ForceMode.Impulse);
    }

    void Update()
    {
        if (ballLaunched)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
