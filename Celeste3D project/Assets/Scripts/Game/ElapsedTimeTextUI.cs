using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ElapsedTimeTextUI : MonoBehaviour
{
  public GameManager gameManager;

	private TextMeshProUGUI textController;

	private void Start() {
		textController = gameObject.GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		textController.text = formattedTime();
	}

	private string formattedTime() {
		int time = int.Parse(gameManager.elapsedTime.ToString("#"));

		int minutes = time / 60;
		int seconds = time % 60;

		return (minutes.ToString()) + ":" + ((seconds >= 10 ? "" : "0") + seconds.ToString());
	}
}
