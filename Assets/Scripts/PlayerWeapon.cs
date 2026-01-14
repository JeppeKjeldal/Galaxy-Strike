using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 250f;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            //Subratct the laser position from the target point position, which returns a vector between the two points
            Vector3 fireDirection = targetPoint.position - transform.position;

            //Create a rotation that looks in the direction of the fireDirection vector
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);

            //Apply the rotation to the laser
            laser.transform.rotation = rotationToTarget;
        }
    }
}
