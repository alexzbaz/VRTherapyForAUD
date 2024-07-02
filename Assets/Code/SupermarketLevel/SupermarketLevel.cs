using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketLevel : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject beer;
    [SerializeField] private GameObject wine;
    [SerializeField] private GameObject whiskey;
    [SerializeField] private GameObject vodka;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        beer.SetActive(false);
        wine.SetActive(false);
        whiskey.SetActive(false);
        vodka.SetActive(false);
        if (gameManager.alcoholSelected == AlcoholType.BEER)
        {
            beer.SetActive(true);
        }
        else if (gameManager.alcoholSelected == AlcoholType.WINE)
        {
            wine.SetActive(true);
        }
        else if (gameManager.alcoholSelected == AlcoholType.WHISKEY)
        {
            whiskey.SetActive(true);
        }
        else if (gameManager.alcoholSelected == AlcoholType.VODKA)
        {
            vodka.SetActive(true);
        }
    }
}
