using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] CinemachineFreeLook freeLookCamera;

    [SerializeField] private float mouseLookSensitivity = 0.5f;

    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            freeLookCamera.Priority = 100;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            freeLookCamera.Priority = 0;
            freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
        }

        if (Input.GetMouseButtonDown(1) == false)
        {
            var vertical = Input.GetAxis("Mouse Y") * mouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
        }

    }
}
