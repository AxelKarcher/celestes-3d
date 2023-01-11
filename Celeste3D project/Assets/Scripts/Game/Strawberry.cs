using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
	private StatsManager sm;
	private AudioSource audioSource;
	private MeshRenderer mr;
	private bool isPickedUp = false;

  public GameObject player;

	private void Start() {
		sm = player.GetComponent<StatsManager>();
		mr = gameObject.GetComponent<MeshRenderer>();
    	audioSource = gameObject.GetComponent<AudioSource>();
	}

    private void Update() {
        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);

		if (isPickedUp) {
			Invoke(nameof(HandleDestroy), 2);
		}
    }

	private void HandleDestroy() {
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider collider) {
		if (!isPickedUp && collider.gameObject.tag == "Player") {
			isPickedUp = true;
			audioSource.Play();
			mr.enabled = false;
			sm.strawberries += 1;
		}
	}
}
