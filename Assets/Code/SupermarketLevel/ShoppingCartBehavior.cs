using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartBehavior : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    [SerializeField] private GameObject playerCapsule;
    [SerializeField] private GameObject supermarket;

    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void Grab(Transform objectGrabPointTransform)
	{
        Debug.Log("Grab Cart");
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = true;
        this.gameObject.transform.parent = playerCapsule.transform;
        this.gameObject.transform.position = new Vector3(playerCapsule.transform.position.x, playerCapsule.transform.position.y, playerCapsule.transform.position.z * 1.5f);
    }

    public void Leave()
	{
        Debug.Log("Drop Cart");
        objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        this.gameObject.transform.parent = supermarket.transform;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 newPosition = new Vector3(objectGrabPointTransform.position.x, 0, objectGrabPointTransform.position.z);
            objectRigidbody.MovePosition(newPosition);
            transform.position = newPosition;
        }
    }
}
