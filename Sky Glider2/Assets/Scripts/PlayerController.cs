using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public Vector3 rotationSpeed = new Vector3(50, 0, 0);
    public bool ballLaunched = false;
    [SerializeField] private CameraSwitcher cameraSwitcher;

    public float forwardForce = 50f;
    public float upwardForce = 15f;

    private void Start()
    {
        cameraSwitcher = GameObject.Find("Main Camera").GetComponent<CameraSwitcher>();
    }
    public void LaunchBall(float pullAmount)
    {
        cameraSwitcher.transitionStarted = true;

        ballLaunched = true;
        transform.parent = null;
        rb.isKinematic = false;

        // Kuvvet miktarini pullAmount ile belirle
        forwardForce *= pullAmount;
        upwardForce *= pullAmount;

        rb.AddForce(new Vector3(0, upwardForce, forwardForce), ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (ballLaunched)
        {
            transform.Rotate(rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
