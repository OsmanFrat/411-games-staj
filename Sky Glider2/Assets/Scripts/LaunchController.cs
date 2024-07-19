using UnityEngine;
using DG.Tweening;

public class LaunchController : MonoBehaviour
{
    
    public Animator animator;
    private bool isPulling = false;
    private Vector3 mouseStartPosition;
    private float pullAmount;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CameraSwitcher cameraSwitcher;
   

    [SerializeField] private RocketManController controller;

    public bool playerThrown = false;

    private void Start()
    {
        
        cameraSwitcher = GameObject.Find("Main Camera").GetComponent<CameraSwitcher>();
        
    }

    void Update()
    {

        if (!playerThrown)
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
                animator.Play("New State 0", 0, pullAmount);
            }

            if (Input.GetMouseButtonUp(0))
            {

                animator.Play("New State 1", 0, 1 - pullAmount);
                

            }
        }
        
    }

    public void Throw()
    {
        playerThrown = true;

        cameraSwitcher.transitionStarted = true;
        rb.gameObject.transform.parent = null;
        rb.isKinematic = false;
        
        float forwardForce = 60f * pullAmount;
        float upwardForce = 40f * pullAmount;
        
        rb.AddForce(new Vector3(0, upwardForce, forwardForce), ForceMode.Impulse);

        
       
        controller.StartRotation();
        
        print("fırladı");
        
    }
    
    
   
    
}   