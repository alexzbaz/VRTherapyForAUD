using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pointsystem : MonoBehaviour
{
    public static int points;
    public TMP_Text pointsText;
    private AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake Point System");
        points = 0;
        Debug.Log("Points: " + points);
        audio = GetComponent<AudioSource>();
    }

    public int getPoints()
	{
        return points;
	}

    public void updateText()
	{
        pointsText.text = points.ToString();
	}

    public void playSound()
	{
        audio.Play();
	}

    public void add50Points()
	{
        Debug.Log("Points before: " + points);
        points += 50;
        Debug.Log("Points after: " + points);
        updateText();
        playSound();
    }

    public void add100Points()
	{
        points += 100;
        updateText();
        playSound();
    }

    public void add200Points()
	{
        points += 200;
        updateText();
        playSound();
    }

    public void deduct20Points()
	{
        if (points >= 20)
		{
            points -= 20;
            updateText();
        }
	}

    public void deduct50Points()
	{
        if (points >= 50)
        {
            points -= 50;
            updateText();
        }
	}
}
