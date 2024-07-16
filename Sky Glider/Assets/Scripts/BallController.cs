using UnityEngine;

public class BallController : MonoBehaviour
{
    public Animator animator;
    private bool isPulling = false;
    private Vector3 mouseStartPosition;
    private float pullAmount;

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
            pullAmount = 0f;
            
        }

    }

    public void Throw()
    {
        Debug.Log("Ball launched!");
    }
}