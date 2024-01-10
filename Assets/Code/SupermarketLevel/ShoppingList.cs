using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    //private Dictionary<string, bool> shoppingList;
    // public bool allItemsInCart = false;
    private bool pointsGiven;

    // Pointsystem
    //[SerializeField] private string compareTag;
    [SerializeField] private Pointsystem pointsystem;

    void Awake()
    {
        //compareTag = "InnerInventory";
        pointsGiven = false;
    }

    //void Update()
    //{
    //    if (transform.parent.parent.name == compareTag && pointsGiven == false)
    //    {
    //        pointsGiven = true;
    //        pointsystem.add100Points();
    //        Debug.Log(transform.parent.parent);
    //    }
    //}

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Bread") || collider.CompareTag("Chips") || collider.CompareTag("Water") || collider.CompareTag("Pasta") || collider.CompareTag("Milk") || collider.CompareTag("Cereal") || collider.CompareTag("Eggs"))
        {
            Debug.Log("Enter");
            if (collider.transform.childCount == 0 && pointsGiven == false)
            {
                pointsGiven = true;
                Debug.Log("Add");
                pointsystem.add100Points();
                Debug.Log(pointsystem.getPoints());
            }
        }
    }
}


        //               //      switch (collider.CompareTag()
        //               //{
        //               //          case "Bread":
        //               //              shoppingList["Bread"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Chips":
        //               //              shoppingList["Chips"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Water":
        //               //              shoppingList["Water"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Pasta":
        //               //              shoppingList["Pasta"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Milk":
        //               //              shoppingList["Milk"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Cereal":
        //               //              shoppingList["Cereal"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          case "Eggs":
        //               //              shoppingList["Eggs"] = true;
        //               //              pointsystem.add100Points();
        //               //              break;
        //               //          default:
        //               //              break;
        //               //      }

//               //      int counter = 0;
//               //      // Check if all items are in cart
//               //      foreach(var item in shoppingList.Values)
//               //{
//               //          if (item == true)
//               //	{
//               //              counter += 1;
//               //	}

//               //          if (counter == shoppingList.Count)
//               //	{
//               //              allItemsInCart = true;
//               //	}
//               //}
//           }



//       // Important that all names of the products are written exactly like the tags in the Editor
//   private void initShoppingList()
//{
//       shoppingList = new Dictionary<string, bool>();
//       shoppingList.Add("Bread", false);
//       shoppingList.Add("Chips", false);
//       shoppingList.Add("Water", false);
//       shoppingList.Add("Pasta", false);
//       shoppingList.Add("Milk", false);
//       shoppingList.Add("Cereal", false);
//       shoppingList.Add("Eggs", false);
//   }
