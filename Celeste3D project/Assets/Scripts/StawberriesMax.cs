using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StawberriesMax : MonoBehaviour
{
  	private TextMeshProUGUI textController;

	private void Start() {
		textController = gameObject.GetComponent<TextMeshProUGUI>();
		textController.text = "/ " + GameObject.FindGameObjectsWithTag("Strawberry").Length.ToString();
	}
}
