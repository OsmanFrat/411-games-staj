using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public float duration = 0.5f; 
    public float strength = 1.0f; 
    public int vibrato = 10; 
    public float randomness = 90f;

    public Bomb bomb;

    private void Update()
    {
        if (bomb.bombActivated)
        {
            ShakeCamera();
        }
    }
    public void ShakeCamera()
    {
        
        Transform cameraTransform = Camera.main.transform;

        cameraTransform.DOShakePosition(duration, strength, vibrato, randomness);
    }
}

