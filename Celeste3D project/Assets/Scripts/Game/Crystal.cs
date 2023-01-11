using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
	public Material onMaterial;
	public Material offMaterial;

	public AnimationScript animScript;
	private PlayerMovement pm;

	private AudioSource audioSource;

	private MeshRenderer meshRenderer;

	private float timerRemaining;
	private bool isTimerStarted = false;
	public float resetTime;

	private bool isPickedUp = false;

  public GameObject player;

	private void Start() {
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
		audioSource = gameObject.GetComponent<AudioSource>();
    pm = player.GetComponent<PlayerMovement>();

		meshRenderer.material = onMaterial;
		animScript.isRotating = true;
	}

	private void Update() {
		if (timerRemaining <= 0) {
			isTimerStarted = false;
			meshRenderer.material = onMaterial;
			animScript.isRotating = true;
			isPickedUp = false;
		} else if (isTimerStarted) {
			timerRemaining -= Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider collider) {
		if (!isPickedUp && timerRemaining <= 0 && collider.gameObject.tag == "Player") {
			isPickedUp = true;
      pm.canDash = true;
      		meshRenderer.material = offMaterial;
			audioSource.Play();
			animScript.isRotating = false;
			isTimerStarted = true;
			timerRemaining = resetTime;
		}
	}
}
