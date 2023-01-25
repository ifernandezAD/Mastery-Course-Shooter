using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] private float mouseLookSensitivity = 0.5f;

    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();   
    }

    void Update()
    {
        var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
        aim.m_TrackedObjectOffset.y += vertical;
    }
}
