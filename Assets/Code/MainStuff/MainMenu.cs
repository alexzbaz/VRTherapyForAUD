using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	private GameManager gameManager;

	public Toggle homeToggle;
	public Toggle supermarketToggle;
	public Toggle barToggle;
	public Toggle partyToggle;
	public ToggleGroup toggleGroupSettings;

    public Toggle wineToggle;
    public Toggle beerToggle;
    public Toggle whiskeyToggle;
    public Toggle vodkaToggle;
    public ToggleGroup toggleGroupCustomize;

    public Button backButton1;
	public Button backButton2;

    private void Start()
	{
		gameManager = GameManager._instance;
	}

	public void Update()
	{
		backButton1.onClick.AddListener(() => { levelSelection(); });
        backButton2.onClick.AddListener(() => { alcoholSelection(); });
    }

	// Is called from Editor
	public void PlayGame()
	{
		gameManager.LoadScene(2); // Start at the forest
	}

	// Is called from Editor
	public void QuitGame()
	{
		Application.Quit();
	}

	private void levelSelection()
	{
		if (homeToggle.isOn)
		{
			gameManager.levelSelected = Scenes.HOME;
		}
		else if (supermarketToggle.isOn)
		{
			gameManager.levelSelected = Scenes.SUPERMARKET;
		}
		else if (barToggle.isOn)
		{
			gameManager.levelSelected = Scenes.BAR;
		}
		else if (partyToggle.isOn)
		{
			gameManager.levelSelected = Scenes.PARTY;
		}
	}

	private void alcoholSelection()
	{
        if (beerToggle.isOn)
        {
            gameManager.alcoholSelected = AlcoholType.BEER;
        }
        else if (wineToggle.isOn)
        {
            gameManager.alcoholSelected = AlcoholType.WINE;
        }
        else if (whiskeyToggle.isOn)
        {
            gameManager.alcoholSelected = AlcoholType.WHISKEY;
        }
        else if (vodkaToggle.isOn)
        {
            gameManager.alcoholSelected = AlcoholType.VODKA;
        }
    }

	// Is called from Editor
	public void homeLevelCustomization(Toggle toggle)
	{
		if (toggle.name == "CleanToggle")
		{
			if (toggle.isOn)
			{
				// TODO: Hier müssen alle Einstellungen für Cleaning-Level rein
			}
		} 
		else if (toggle.name == "DisposeAlcToggle")
		{
			if (toggle.isOn)
			{
				// TODO: Hier müssen alle Einstellungen für Dispose-Level rein
			}
		}
	}

}
