using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    private Dictionary<string, bool> shoppingList;
    public bool allItemsInCart = false;

    void Awake()
    {
        initShoppingList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
        //Debug.Log("Collision Entered");
        switch (collision.gameObject.tag)
		{
            case "Jam":
                shoppingList["Jam"] = true;
                Debug.Log("Jam in Cart");
                break;
            case "Bread":
                shoppingList["Bread"] = true;
                Debug.Log("Bread in Cart");
                break;
            case "Chips":
                shoppingList["Chips"] = true;
                break;
            case "Water":
                shoppingList["Water"] = true;
                break;
            case "Zewa":
                shoppingList["Zewa"] = true;
                break;
            case "Laundry":
                shoppingList["Laundry"] = true;
                break;
            case "Yoghurt":
                shoppingList["Yoghurt"] = true;
                break;
            case "Cheese":
                shoppingList["Cheese"] = true;
                break;
            case "Milk":
                shoppingList["Milk"] = true;
                break;
            case "Cereal":
                shoppingList["Cereal"] = true;
                break;
            default:
                break;
        }

        int counter = 0;
        // Check if all items are in cart
        foreach(var item in shoppingList.Values)
		{
            if (item == true)
			{
                counter += 1;
			}

            if (counter == shoppingList.Count)
			{
                allItemsInCart = true;
			}
		}
        //Debug.Log("Counter " + counter);
    }

	// Important that all names of the products are written exactly like the tags in the Editor
	private void initShoppingList()
	{
        shoppingList = new Dictionary<string, bool>();
        shoppingList.Add("Jam", false);
        shoppingList.Add("Bread", false);
        shoppingList.Add("Chips", false);
        shoppingList.Add("Water", false);
        shoppingList.Add("Zewa", false);
        shoppingList.Add("Laundry", false);
        shoppingList.Add("Yoghurt", false);
        shoppingList.Add("Cheese", false);
        shoppingList.Add("Milk", false);
        shoppingList.Add("Cereal", false);
    }
}
