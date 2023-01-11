using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameColorUI : MonoBehaviour
{
	public Sprite canDash;
	public Sprite cantDash;

	private Image image;

	private PlayerMovement pm;
	public GameObject player;

	private void Start() {
		pm = player.GetComponent<PlayerMovement>();
		image = gameObject.GetComponent<Image>();
	}

	private void Update() {
       image.sprite = pm.canDash ? canDash : cantDash;
	}
}
