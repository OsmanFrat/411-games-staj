using System;
using UnityEngine;
using DG.Tweening;

public class RocketManController : MonoBehaviour
{
    public Animator animator;

    private bool isPulling = false;
    private float startTime;
    private float holdTime;
    private float maxHoldTime = 0.2f;
    private float normalizedOpenTime;
    private float normalizedCloseTime;
    public bool isLaunched;
    public bool hasLaunched = false;
    private Tween rotateTween;
    private bool openWingsOnce;

    private Vector3 slowGravity = new Vector3(0, -4f, 0);
    private Vector3 normalGravity = new Vector3(0, -9.8f, 0);

    private float lastMouseX;
    public float movementForce = 10f; // Adjust this value as needed
    public float mouseSensitivity = 0.5f; // Add a sensitivity variable

    public Quaternion oldRotation;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform yawTransform;
    private Tweener yawTween;

    private void Start()
    {
        
        lastMouseX = Input.mousePosition.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPulling = true;
            startTime = Time.time;
            animator.SetBool("pull", isPulling);
            lastMouseX = Input.mousePosition.x;
        }

        if (hasLaunched)
        {
            if (Input.GetMouseButton(0) && isPulling)
            {
                holdTime = Time.time - startTime;
                normalizedOpenTime = Mathf.Clamp01(holdTime / maxHoldTime);
                animator.Play("openWings", 0, normalizedOpenTime);
                Physics.gravity = slowGravity;

                float mouseX = Input.mousePosition.x;
                float deltaX = (mouseX - lastMouseX) * mouseSensitivity; // Apply sensitivity

                if (Mathf.Abs(deltaX) > 0.1f)
                {
                    float targetZRotation = 0;
                    Vector3 forceDirection = Vector3.zero;
                    if (deltaX > 0)
                    {
                        // Rotate to the right
                        targetZRotation = -45;
                        forceDirection = Vector3.right;
                    }
                    else
                    {
                        // Rotate to the left
                        targetZRotation = 45;
                        forceDirection = Vector3.left;
                    }
                    if (yawTween == null)
                    {
                        yawTween = yawTransform.transform.DORotate(new Vector3(35, 0, targetZRotation), 0.4f, RotateMode.Fast).SetAutoKill(false);

                    }
                    else
                    {
                        yawTween.ChangeEndValue(new Vector3(35, 0, targetZRotation), 0.4f, true).Restart();
                    }
                    
                    rb.AddForce(forceDirection * movementForce, ForceMode.VelocityChange);
                    lastMouseX = mouseX;
                }

                if (!openWingsOnce)
                {
                   // StopRotation();
                    openWingsOnce = true;
                }
            }

            if (Input.GetMouseButtonUp(0) && isPulling)
            {

                isPulling = false;
                animator.SetBool("pull", isPulling);
                holdTime = Time.time - startTime;
                normalizedCloseTime = Mathf.Clamp01(holdTime / maxHoldTime);
                animator.Play("closeWings", 0, 1 - normalizedCloseTime);
                Physics.gravity = normalGravity;

                yawTween.ChangeEndValue(new Vector3(0, 0, 0), 0.4f, true).Restart();
                if (openWingsOnce)
                {
                    //if (yawTween == null)
                    //{
                    //    yawTween = yawTransform.transform.DORotate(new Vector3(35, 0, 0), 0.4f, RotateMode.Fast);
                    //}
                    //else
                    //{
                    //    yawTween.ChangeEndValue(new Vector3(0, 0, 0), 0.4f);
                    //}

                    //yawTransform.transform.DORotate(new Vector3(0, 0, 0), 0.4f, RotateMode.Fast);
                    StartRotation();
                    
                    openWingsOnce = false;
                }
            }
        }
    }

    public void StartRotation()
    {
        print("dönüyor");
        isLaunched = true;
        hasLaunched = true;
        //if (isLaunched)
        //{
        //    if (rotateTween != null)
        //    {
        //        rotateTween.Pause();
        //    }
        //    rotateTween = rb.gameObject.transform.DORotate(new Vector3(360, 0, 0), 0.6f, RotateMode.FastBeyond360)
        //        .SetEase(Ease.Linear)
        //        .SetLoops(-1, LoopType.Incremental).SetRelative();
        //}
    }

    public void StopRotation()
    {
        rotateTween.Pause();
        rotateTween = transform.DORotate(new Vector3(35, 0, 0), 0.2f, RotateMode.Fast);
    }

    
}
