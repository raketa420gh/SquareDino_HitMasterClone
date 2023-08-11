using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour, ICameraController
{
    [SerializeField] private CinemachineVirtualCamera _followCamera;
    
    public void SetFollowCamera(Transform target)
    {
        _followCamera.Follow = target;
        _followCamera.LookAt = target;
    }
}