using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableScript : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;

    void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
	{
        Debug.Log("Grab");
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
	}

    public void Drop()
	{
        Debug.Log("Drop");
        objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
	}

	private void FixedUpdate()
	{
		if (objectGrabPointTransform != null)
		{
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
		}
	}

}
