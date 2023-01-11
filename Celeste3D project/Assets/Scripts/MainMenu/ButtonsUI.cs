using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    public void goToGameScene() {
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}

	public void quitApplication() {
		Application.Quit();
	}

	private void Start() {
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
    }
}
