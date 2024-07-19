using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CameraSwitcher cameraSwitcher;
    public bool ballLaunched = false;

    public Animator animator;
    
    public Vector3 rotationSpeed = new Vector3(50, 0, 0);
    
    
    

    public float forwardForce = 50f;
    public float upwardForce = 15f;

    public bool wingAniStarted = false;

    private Quaternion targetRotation;
    private float rotationSpeedSmooth = 2.0f; // donus ile kanat acilma arasi smooth anim. degeri

    private Vector3 normalGravity = new Vector3(0, -9.81f, 0);
    public Vector3 slowGravity = new Vector3(0, -4f, 0);

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

        // Kuvvet  pullAmount ile belirle
        forwardForce *= pullAmount;
        upwardForce *= pullAmount;

        rb.AddForce(new Vector3(0, upwardForce, forwardForce), ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (ballLaunched)
        {
            if (!wingAniStarted)
            {
                transform.Rotate(rotationSpeed * Time.fixedDeltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("wings", true);
                Physics.gravity = slowGravity;

                SetRotation();
            }

            if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("wings", false);
                Physics.gravity = normalGravity;
                wingAniStarted = false;
            }

            if (wingAniStarted)
            {
                SmoothRotateToTarget();
            }
        }
    }

    public void SetRotation()
    {
        wingAniStarted = true;

        Vector3 currentRotation = transform.eulerAngles;
        targetRotation = Quaternion.Euler(90f, currentRotation.y, currentRotation.z);

        print("top çevrildi");
    }
    
    
    private void SmoothRotateToTarget()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeedSmooth);
    }


}
