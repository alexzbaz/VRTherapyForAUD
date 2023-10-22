using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;

	public int sceneNum;

    private static GameManager Instance
	{
		get
		{
			if (_instance is null)
			{
				Debug.LogError("Game Manager is null");
			}

			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		DontDestroyOnLoad(this); // A GameManager should exist after the Level is destroyed and a new level is loaded.
	}

	private void Start()
	{
		sceneNum = 0;
	}

	// Use this function to load the specific level from the forest
	void LoadScene(int scene)
	{
		SceneManager.LoadScene(scene);
	}

	// For testing purposes
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			NextScene();
		}
	}

	// For testing purposes
	void NextScene()
	{
		sceneNum++;
		if (sceneNum == 5)
		{
			sceneNum = 0;
		}
		SceneManager.LoadScene(sceneNum);
	}
}
