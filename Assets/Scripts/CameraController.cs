using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [Header("Third Person")]
    [SerializeField] CinemachineVirtualCamera followCamera;
    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] private float thirdPersonLookSensitivity = 1f;

    [Header("First Person")]
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] private float firstPersonLookSensitivity = 1f;

    private CinemachineComposer aim;

   

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            var vertical = Input.GetAxis("Mouse Y") * thirdPersonLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
        }

        var fpsVertical = Input.GetAxis("Mouse Y") * firstPersonLookSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);

    }
}
