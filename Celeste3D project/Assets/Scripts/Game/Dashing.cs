using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerMovement pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float maxDashYSpeed;
    public float dashDuration;
    private AudioSource audioSource;

    [Header("CameraEffects")]
    public PlayerCam cam;
    public float dashFov;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
		    audioSource = GetComponent<AudioSource>();
    }

    private void Update()  {
        if (pm.canDash && Input.GetKeyDown(dashKey)) {
            Dash();
		}
    }

    private void Dash() {
		audioSource.Play();

		pm.canDash = false;
        pm.dashing = true;
        pm.maxYSpeed = maxDashYSpeed;

        cam.DoFov(dashFov);

        Vector3 direction = GetDirection(playerCam);

        Vector3 forceToApply = direction * dashForce + orientation.up * dashUpwardForce;

        rb.useGravity = false;

        delayedForceToApply = forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private Vector3 delayedForceToApply;
    private void DelayedDashForce() {
        rb.velocity = Vector3.zero;

        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash() {
        pm.dashing = false;
        pm.maxYSpeed = 0;

        cam.DoFov(85f);

        rb.useGravity = true;
    }

    private Vector3 GetDirection(Transform forwardT) {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3();

        direction = forwardT.forward * verticalInput + forwardT.right * horizontalInput;

        if (verticalInput == 0 && horizontalInput == 0) {
            direction = forwardT.forward;
		}

        return direction.normalized;
    }
}