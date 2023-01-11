using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour
{
  public GameManager gameManager;

  private void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.tag == "Player") {
      gameManager.setRespawnPoint(gameObject.transform.position);
    }
  }
}
