using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Rigidbody reference
    public Rigidbody rb;

    [SerializeField] private float forwardForce = 2000f;
    [SerializeField] private float sidewaysForce = 500f;
    [SerializeField] private bool dButtonPressed = false;
    [SerializeField] private bool aButtonPressed = false;


    private void Update()
    { 
        
        if (Input.GetKey(KeyCode.D))
        {
            dButtonPressed = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            aButtonPressed = true;
        }
        
    }

    // Using FixedUpdate because we are doing physic stuff.
    void FixedUpdate()
    {
        // Adding forward force to player
        rb.AddForce(forwardForce * Time.deltaTime, 0, 0);

        if (dButtonPressed)
        {
            /*
            Vector3 currentPosition = transform.position;
            currentPosition.z += -0.2f;
            transform.position = currentPosition;
            */
            rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            dButtonPressed = false;
        }
        
        if (aButtonPressed)
        {
            rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            aButtonPressed = false;
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
