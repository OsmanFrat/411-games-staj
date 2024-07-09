using UnityEngine;

public class Accell : MonoBehaviour
{
    public Rocket rocket;
    public float accel = 10f;
    public void Accellation()
    {
        if(rocket.followerSpeed != 100)
        {
            rocket.followerSpeed += accel;
        }
        else
        {
            rocket.followerSpeed =  100;
        }
    }
}
