using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointsystem : MonoBehaviour
{
    public static int points;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awake Point System");
        points = 0;
        Debug.Log("Points: " + points);
    }

    public int getPoints()
	{
        return points;
	}

    public void add50Points()
	{
        Debug.Log("Points before: " + points);
        points += 50;
        Debug.Log("Points after: " + points);
    }

    public void add100Points()
	{
        points += 100;
	}

    public void add200Points()
	{
        points += 200;
	}

    public void deduct20Points()
	{
        if (points >= 20)
		{
            points -= 20;
        }
	}

    public void deduct50Points()
	{
        if (points >= 50)
        {
            points -= 50;
        }
	}
}
