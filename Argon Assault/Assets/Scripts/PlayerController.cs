using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Project.Scripts
{

    public class PlayerController : MonoBehaviour 
    {

        [Header("Space Ship Settings")]

        [Tooltip("Speed of our space ship.")]
        [SerializeField] float controlSpeed = 20f;

        [Tooltip("How much can our ship go on x-axis.")] 
        [SerializeField] float xRange = 5f;

        [Tooltip("How much can our ship go on y-axis.")] 
        [SerializeField] float yRange = 3f;

        [Tooltip("Laser beam array.")]
        [SerializeField] GameObject[] guns;

        [Header("Screen position settings")]
        [SerializeField] float positionPitchFactor = -5f;
        [SerializeField] float positionYawFactor = 5f;

        [Header("Control based throw")]
        [SerializeField] float controlPitchFactor = -20f;
        [SerializeField] float controlRollFactor = -20f;

        private float xThrow, yThrow;

        private bool isControlEnabled = true;

    
        private void Update()
        {
            if (isControlEnabled)
            {
                ProcessTranslation();
                ProcessRotation();
                ProcessFiring();
            }
        }

        private void OnPlayerDeath()
        {
            isControlEnabled = false;
        }

        private void ProcessRotation()
        {
            float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
            float pitchDueToControlThrow = yThrow * controlPitchFactor;
            float pitch = pitchDueToPosition + pitchDueToControlThrow;

            float yaw = transform.localPosition.x * positionYawFactor;

            float roll = xThrow * controlRollFactor;

            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }

        private void ProcessTranslation()
        {
            xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            yThrow = CrossPlatformInputManager.GetAxis("Vertical");

            float xOffset = xThrow * controlSpeed * Time.deltaTime;
            float yOffset = yThrow * controlSpeed * Time.deltaTime;

            float rawXPos = transform.localPosition.x + xOffset;
            float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

            float rawYPos = transform.localPosition.y + yOffset;
            float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

            transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        }
        private void ProcessFiring()
        {
            if (CrossPlatformInputManager.GetButton("Fire"))
                SetGunsActive(true);
            else
                SetGunsActive(false);
        }
        private void SetGunsActive(bool isActive)
        {
            foreach (GameObject gun in guns) 
            {
                var emissionModule = gun.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = isActive;
            }
        }
    }
}
