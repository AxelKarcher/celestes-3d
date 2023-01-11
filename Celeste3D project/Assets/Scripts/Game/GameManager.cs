using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  // audio
  private AudioSource audioSource;
  public AudioClip checkpointSound;
	public AudioClip deathSound;

	public float elapsedTime = 0f;

  public GameObject player;
  private StatsManager sm;
  public GameObject UICanvas;
  public GameObject endGameCanvas;
  public bool gameEnded = false;
  public Vector3 respawnPoint = new Vector3(0f, 10f, 0f);

  private void Start() {
    audioSource = gameObject.GetComponent<AudioSource>();
    sm = player.GetComponent<StatsManager>();
    endGameCanvas.SetActive(false);
  }

	private void Update() {
    // back to menu
    if (Input.GetKeyDown(KeyCode.Escape)) {
      SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    // end game setup
    if (gameEnded) {
      endGameCanvas.SetActive(true);
      UICanvas.SetActive(false);
      player.SetActive(false);
    } else {
      // timer inscreasing
      elapsedTime += Time.deltaTime;
    }

    if (player.transform.position.y <= 0) {
      handleDeath();
    }
	}

  public void setRespawnPoint(Vector3 newPos) {
    if (respawnPoint != newPos) {
      audioSource.PlayOneShot(checkpointSound);
    }
    respawnPoint = newPos;
  }

  public void handleDeath() {
			player.transform.position = respawnPoint;
			sm.deaths += 1;
			audioSource.PlayOneShot(deathSound, 0.5f);
  }
}
