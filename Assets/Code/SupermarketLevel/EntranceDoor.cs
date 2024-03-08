using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject entrance;
    public ShoppingList shoppingList;

    [SerializeField] private bool rightDoor; // Set in Editor
    [SerializeField] private bool exitDoor; // Set in Editor
    private bool doorOpened = false;

	// Update is called once per frame
	void Update()
    {
        Collider[] doorColliders = Physics.OverlapSphere(transform.position, 2f, playerLayer);

        if (!exitDoor)
        {
            if (doorColliders.Length > 0)
            {
                if (!doorOpened)
                {
                    doorOpened = true;
                    if (rightDoor)
                    {
                        entrance.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    }
                    else
                    {
                        entrance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }

                }
            }
            else
            {
                if (doorOpened)
                {
                    entrance.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                    doorOpened = false;
                }
            }
        }

  //      if (exitDoor)
		//{
  //          if (rightDoor)
		//	{
  //              if (shoppingList.allItemsInCart)
  //              {
  //                  entrance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
  //              }
  //          }
		//}
    }
}
