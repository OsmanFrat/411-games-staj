using UnityEngine;

public class StickController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private bool isPulling = false;
    [SerializeField] private Vector3 mouseStartPosition;
    [SerializeField] private float pullAmount;
    [SerializeField] private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPulling = true;
            mouseStartPosition = Input.mousePosition;
            animator.SetBool("pull", isPulling);
        }

        if (Input.GetMouseButton(0) && isPulling)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 difference = currentMousePosition - mouseStartPosition;

            pullAmount = Mathf.Clamp(-difference.x / Screen.width, 0f, 1f);

            animator.Play("PullAni", 0, pullAmount);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.Play("ReleaseAni", 0, 1 - pullAmount);
            //Throw();
            pullAmount = 0f;
            isPulling = false;
        }
    }

    
    public void Throw()
    {
        playerController.LaunchBall(pullAmount); // Pass pullAmount to PlayerController
    }
}
