using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartBehavior : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

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
    }

    public void Leave()
	{
        Debug.Log("Drop Cart");
        objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
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
