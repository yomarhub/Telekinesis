using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public SpringArm springArm;

    [Header("Settings")]
    [SerializeField] private float sensibility = 2.0f;
    public bool isInvertedY = true;
    public Vector2 pitchLimits = new(-40.0f, 80.0f);

    private float pitch = 0;
    private float yaw = 0;
    private Transform tCam;
    private Vector3 cameraOffset;

    public void Start()
    {
        tCam = springArm.Camera.transform;
        cameraOffset = tCam.localPosition;
    }

    public void Update()
    {
        // Yaw
        yaw += playerController.lookInputValue.x * sensibility;

        // Pitch
        pitch += playerController.lookInputValue.y * sensibility;
        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        playerController.character.transform.localRotation = Quaternion.Euler(0, yaw, 0);
        springArm.transform.localRotation = Quaternion.Euler(pitch * (isInvertedY ? 1 : -1), 0, 0);

        Vector3 playerPosition = playerController.character.transform.position;
        if (Physics.Linecast(playerPosition, springArm.transform.position + springArm.transform.rotation * cameraOffset, out RaycastHit hit))
        {
            tCam.localPosition = new(0, 0, -Vector3.Distance(playerPosition, hit.point + new Vector3(.0f, .0f, 0.5f)));
        }
        else
        {
            tCam.localPosition = new(0, 0, Mathf.Lerp(tCam.localPosition.z, cameraOffset.z, Time.deltaTime));
        }
    }
}
