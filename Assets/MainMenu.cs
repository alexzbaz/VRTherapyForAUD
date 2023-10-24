using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.Instance;
	}

	public void PlayGame()
	{
		gameManager.LoadScene(0); // Start at the forest
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
