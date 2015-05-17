using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour 
{
	public GameObject playButton;

	public void Start()
	{
		playButton.SetActive(true);
	}

	public void OnPlay(string level)
	{
		Application.LoadLevel(level);
		return;
	}
}
