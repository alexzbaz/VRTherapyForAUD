using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
	public Transform playerCameraTransform;
	public Transform objectGrabPointTransform;
	public LayerMask pickUpLayerMask;
	public LayerMask shoppingCartLayer;

	private GrabbableScript objectGrabbable;
	public ShoppingCartBehavior shoppingCart;
	public bool grabbed = false;
	public bool shoppingCartGrab = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (grabbed == false)
			{
				float pickUpDistance = 2.5f;
				if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
				{
					if (raycastHit.transform.TryGetComponent(out objectGrabbable))
					{
						objectGrabbable.Grab(objectGrabPointTransform);
						grabbed = true;
						Debug.Log(objectGrabbable);
					}
				}
			}
			else
			{
				objectGrabbable.Drop();
				objectGrabbable = null;
				grabbed = false;
			}
		}


		if (Input.GetKeyDown(KeyCode.Q)) {
			if (shoppingCartGrab == false)
			{
				Collider[] hitColliders = Physics.OverlapSphere(shoppingCart.transform.position, 2f, shoppingCartLayer);
				Debug.Log(hitColliders[0]);
				if (hitColliders.Length > 0)
				{
					shoppingCart.Grab(objectGrabPointTransform);
					shoppingCartGrab = true;
				}
			}
			else
			{
				shoppingCart.Leave();
				//shoppingCart = null;
				shoppingCartGrab = false;
			}
		}
	}
}
