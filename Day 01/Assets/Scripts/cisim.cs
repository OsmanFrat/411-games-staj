using Dreamteck.Splines;
using UnityEngine;

public class cisim : MonoBehaviour
{
    public GameObject baskaCisim;
    public SplineFollower follower;
    public float startPosition;

    public bool test;
    void Start()
    {
        follower = GetComponent<SplineFollower>();
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            follower.follow = true;
        }
    }
}
