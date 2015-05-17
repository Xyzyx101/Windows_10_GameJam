using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
	public GameObject pauseButton, pausePanel;

	public void Start()
	{
		OnResume();
	}

	public void OnPause()
	{
		pausePanel.SetActive(true);
		pauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	public void OnResume()
	{
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}

	public void OnRestart(string level)
	{
		pausePanel.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
		Application.LoadLevel(level);
		return;
	}
}