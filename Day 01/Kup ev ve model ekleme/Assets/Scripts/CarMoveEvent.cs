using UnityEngine;
using DG.Tweening;
public class CarMoveEvent : MonoBehaviour
{
    [SerializeField] private GameObject car;

    public void CarMove(float endValue, float duration)
    {
        car.transform.DOMoveZ(endValue, duration);
        Debug.Log("Car moved!");
    }

    public void DontCrush()
    {
        CarMove(10, 6);
    }

    public void Crush()
    {
        CarMove(10, 3);
    }
}
