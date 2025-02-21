using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float acceleration = 10.0f;
    public float deceleration = 10.0f;

    [Header("References")]
    public Character character;
    public Animator animator;
    public ThirdPersonCamera thirdPerson;

    [Header("Input Actions")]
    public Vector2 moveInputValue;
    public Vector2 lookInputValue;
    public bool isInteracting;
    public Action OnAttackAction { get; set; }
    public Action<bool> OnInteractAction { get; set; }

    [Header("Debug")]
    public bool isRunning;
    public float runningSpeed = .8f;
    public float walkingSpeed = .5f;
    public float currentSpeed = 0;
    public Vector3 lastMoveDirection = Vector3.zero;

    #region Inputs
    public void OnAttack(InputValue value)
    {
        if (value.Get<float>() > 0)
        {
            OnAttackAction?.Invoke();
        }
    }
    public void OnInteract(InputValue value)
    {
        isInteracting = value.Get<float>() > 0;
        OnInteractAction?.Invoke(isInteracting);
    }
    public void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        lookInputValue = value.Get<Vector2>();
    }
    public void OnSprint(InputValue value)
    {
        isRunning = value.Get<float>() > 0;
    }
    #endregion Inputs

    private void Start()
    {
        thirdPerson = thirdPerson != null ? thirdPerson : GetComponent<ThirdPersonCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float maxSpeed = isRunning ? runningSpeed : walkingSpeed;

        Vector3 right = moveInputValue.x * character.transform.right;
        Vector3 forward = moveInputValue.y * character.transform.forward;
        Vector3 direction = right + forward;

        // Smoothly change speed to better the animation
        if (direction.magnitude > 0.1f)
        {
            lastMoveDirection = direction.normalized;
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * acceleration);

            // Round speed to maxSpeed if it's close enough
            if (Mathf.Abs(currentSpeed - maxSpeed) <= 0.01f) currentSpeed = maxSpeed;
        }
        else currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * deceleration);

        // Move the character
        if (currentSpeed > 0.01f)
        {
            Vector3 velocity = lastMoveDirection * currentSpeed;
            character.Move(velocity * Time.deltaTime);
        }
        else currentSpeed = 0;

        animator.SetFloat("Speed", currentSpeed);
    }

}
