using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrawberriesCounterUI : MonoBehaviour
{
	private TextMeshProUGUI textController;
	private StatsManager sm;

  public GameObject player;

	private void Start() {
		textController = gameObject.GetComponent<TextMeshProUGUI>();

		sm = player.GetComponent<StatsManager>();
	}

	private void Update() {
		textController.text = sm.strawberries.ToString();
	}
}
