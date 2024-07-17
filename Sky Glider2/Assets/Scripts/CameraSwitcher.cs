using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera fixedCamera;
    public CinemachineVirtualCamera followCamera;

    public bool transitionStarted = false;

    void Start()
    {
        fixedCamera.Priority = 15;
        followCamera.Priority = 10;
    }

    private void Update()
    {
        if (transitionStarted)
        {
            CameraSwitch();
        }
    }
    public void CameraSwitch()
    {
        fixedCamera.Priority = 10;
        followCamera.Priority = 15;
    }
}
