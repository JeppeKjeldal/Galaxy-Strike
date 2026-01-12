using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 50f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampRange = 5f;

    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 5f;

    private Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
        PrcessRotation();
    }

    public void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    private void PrcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
