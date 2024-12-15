using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class ClimbingMechanic : MonoBehaviour
{
    [SerializeField]
    InputActionProperty leftHandPositionAction;
    [SerializeField]
    InputActionProperty rightHandPositionAction;
    [SerializeField]
    InputActionProperty leftTriggerAction;
    [SerializeField]
    InputActionProperty rightTriggerAction;
    [SerializeField]
    InputActionProperty jumpAction;

    public bool leftHandClimbing;
    public bool rightHandClimbing;
    public Transform xrOriginTransform;
    public Rigidbody xrOriginRigidbody;

    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;

    private bool isFirstFrame = true;

    private Vector3 startPosition;
    public float fallThresholdY = -10f;

    public float jumpForce = 5f;
    public bool isJumping = false;

    void Start()
    {
        startPosition = xrOriginTransform.position;
    }

    void Update()
    {
        HandleClimbing();
        HandleJumping();
        CheckForFall();
    }

    void HandleClimbing()
    {
        Vector3 currentLeftHandPosition = leftHandPositionAction.action?.ReadValue<Vector3>() ?? Vector3.zero;
        Vector3 currentRightHandPosition = rightHandPositionAction.action?.ReadValue<Vector3>() ?? Vector3.zero;

        float leftTriggerValue = leftTriggerAction.action?.ReadValue<float>() ?? 0f;
        float rightTriggerValue = rightTriggerAction.action?.ReadValue<float>() ?? 0f;

        bool isLeftTriggerPressed = leftTriggerValue > 0.1f && leftHandClimbing;
        bool isRightTriggerPressed = rightTriggerValue > 0.1f && rightHandClimbing;

        bool isClimbing = isLeftTriggerPressed || isRightTriggerPressed;

        xrOriginRigidbody.isKinematic = isClimbing;

        if (isFirstFrame)
        {
            previousLeftHandPosition = currentLeftHandPosition;
            previousRightHandPosition = currentRightHandPosition;
            isFirstFrame = false;
            return;
        }

        if (isClimbing)
        {
            Vector3 movement = Vector3.zero;

            if (isLeftTriggerPressed)
            {
                Vector3 leftHandDelta = currentLeftHandPosition - previousLeftHandPosition;
                movement -= leftHandDelta;
            }

            if (isRightTriggerPressed)
            {
                Vector3 rightHandDelta = currentRightHandPosition - previousRightHandPosition;
                movement -= rightHandDelta;
            }

            xrOriginTransform.position += movement;

            isJumping = false;
        }

        previousLeftHandPosition = currentLeftHandPosition;
        previousRightHandPosition = currentRightHandPosition;
    }

    void HandleJumping()
    {
        if (jumpAction.action != null && jumpAction.action.triggered && !isJumping && !leftHandClimbing && !rightHandClimbing)
        {
            transform.parent = xrOriginTransform;
            xrOriginTransform.parent = null;

            xrOriginRigidbody.isKinematic = false;
            xrOriginRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isJumping = true;
        }

        if (isJumping && xrOriginRigidbody.velocity.y <= 0 && IsGrounded())
        {
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        float distanceToGround = 0.1f;
        return Physics.Raycast(xrOriginTransform.position, Vector3.down, distanceToGround);
    }

    void CheckForFall()
    {
        if (xrOriginTransform.position.y < fallThresholdY)
        {
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        xrOriginTransform.position = startPosition;

        if (xrOriginRigidbody != null)
        {
            xrOriginRigidbody.velocity = Vector3.zero;
            xrOriginRigidbody.angularVelocity = Vector3.zero;
        }

        leftHandClimbing = false;
        rightHandClimbing = false;

        isJumping = false;
        transform.parent = xrOriginTransform;
        xrOriginTransform.parent = null;

        isFirstFrame = true;
    }
}
