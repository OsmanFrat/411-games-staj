using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rocket rocket;
   
    public void Jumping()
    {
        rocket.follower.enabled = false;
        rocket.rb.isKinematic = false;
        //rocket.rb.AddForce(0, 20, 0, ForceMode.Impulse);
        rocket.rb.AddForce(5, 20, 0, ForceMode.Impulse);
        //rocket.follower.enabled = false;
    }
}
