using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Camera pCamera;
    [SerializeField] private Transform objectHolder;

    [Header("Settings")]
    [SerializeField, Range(0.0f, 20.0f)] private float maxDistance = 10.0f;
    private float totalDistance = 0.0f;
    [SerializeField, Range(0.0f, 20.0f)] private float throwForce = 20f;
    [SerializeField, Range(0.0f, 20.0f)] private float lerpSpeed = 10f;
    private bool canGrab;

    [Header("Debug")]
    [SerializeField] private Throwable Grabbed;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private bool drawLine = true;
    public float timeScale = 1f;

    private void CheckCanGrab(bool drawLine = false)
    {
        totalDistance = maxDistance + pCamera.transform.localPosition.magnitude;
        canGrab = Physics.Raycast(pCamera.transform.position, pCamera.transform.forward, out hit, totalDistance);
        canGrab = canGrab && hit.collider.TryGetComponent(out Throwable _);
        if (drawLine) Debug.DrawRay(pCamera.transform.position, pCamera.transform.forward * totalDistance, canGrab ? Color.green : Color.red);
    }
    public void Grab(bool isInteracting)
    {
        CheckCanGrab(drawLine);
        if (isInteracting && Grabbed)
        {
            Grabbed.rb.isKinematic = false;
            //Grabbed.rb.AddForce(pCamera.transform.forward * throwForce, ForceMode.Impulse);
            Grabbed = null;
            playerController.animator.SetTrigger("Throwing");
        }
        else if (isInteracting && canGrab)
        {
            //Debug.Log(hit.collider.name);
            if (hit.collider.TryGetComponent(out Throwable throwable))
            {
                Grabbed = throwable;
                Grabbed.rb.isKinematic = true;
                //Grabbed.transform.SetParent(pCamera.transform);
            }
        }
    }

    public void Throw()
    {
        if (Grabbed)
        {
            Grabbed.rb.isKinematic = false;
            Grabbed.rb.AddForce(pCamera.transform.forward * throwForce, ForceMode.VelocityChange);
            Grabbed = null;
            playerController.animator.SetTrigger("Throwing");
        }
    }

    private void Start()
    {
        playerController.OnInteractAction += Grab;
        playerController.OnAttackAction += Throw;
    }

    private void Update()
    {
        //CheckCanGrab(true);
        if (Grabbed) Grabbed.rb.MovePosition(Vector3.Lerp(Grabbed.transform.position, objectHolder.position, lerpSpeed * Time.deltaTime));
    }

    private void OnValidate()
    {
        Time.timeScale = timeScale;
        objectHolder.localPosition = Vector3.forward * maxDistance / 2;
    }
    private void OnDestroy()
    {
        playerController.OnInteractAction -= Grab;
        playerController.OnAttackAction -= Throw;
    }
}
