using Dreamteck.Splines;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public SplineFollower follower;
    
    [Range(0, 1)]
    [SerializeField] private float startPosition;
    public float followerSpeed;
    public Rigidbody rb;

    public SplineFollower.UpdateMethod selectedUpdateMethod = SplineFollower.UpdateMethod.Update;
    //public SplineFollower.Wrap wrapMode = SplineFollower.Wrap.Default;

    private void Start()
    {
        follower = GetComponent<SplineFollower>();
        rb = GetComponent<Rigidbody>();

        FollowerStartSettings();
        //transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    private void Update()
    {
        FollowerUpdatableSettings();
    }
    private void FollowerUpdatableSettings()
    {
        follower.followSpeed = followerSpeed;
        follower.updateMethod = selectedUpdateMethod;
        //follower.wrapMode = wrapMode;
    }

    private void FollowerStartSettings()
    {
        follower.SetPercent(startPosition);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    follower.gameObject.SetActive(true);
    //}
}
