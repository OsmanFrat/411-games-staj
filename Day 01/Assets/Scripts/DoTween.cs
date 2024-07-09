using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Tween moveTween;
    [SerializeField] private MeshRenderer meshRenderer;
    void Start()
    {
        DotweenTest();
        //Invoke("Stope", 1f);
    }

    void DotweenTest()
    {
        // transform.DOMoveX(10, 5).SetEase(curve).SetDelay(1).OnComplete(()=>print("bitti"));
        //transform.DOShakePosition(1);

        //meshRenderer.sharedMaterial.DOColor(Color.red, 4);
        // meshRenderer.material.DOColor(Color.red, 4); oyun icindeki anlik material degisimi. oyun bitince eskisine duzelir
    }

    private void Stop()
    {
        //moveTween.Pause();
    }

    // sequence test
}
