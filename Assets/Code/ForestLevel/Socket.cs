using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    // Object's position
    public GameObject child;
    [SerializeField] private string compareTag;

    private Transform socketTransform;
    private Transform ring;
    private ObjectHeldTracker heldTracker;
    private Vector3 initialRingScale;



    // Start is called before the first frame update
    void Start()
    {
        socketTransform = this.transform;
        ring = transform.Find("Ring");
        initialRingScale = ring.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Some Collision");
        if (other.CompareTag(compareTag))
        {
            Debug.Log("Inside Collider of Socket");
            ring.localScale *= 1.5f;

            // Get the ObjectHeldTracker component from the colliding object
            heldTracker = other.GetComponent<ObjectHeldTracker>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Some Collision");
        if (other.CompareTag(compareTag))
        {
            Debug.Log("Inside Collider of Socket");
            ring.localScale = initialRingScale;

            heldTracker = null;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(compareTag) && heldTracker != null && !heldTracker.IsHeld())
        {
            Debug.Log("Object is not held and inside collider. Attaching to ring.");

            // Attach the object to the ring

            other.transform.position = ring.position; // Adjust as needed for correct placement
            other.transform.rotation = ring.rotation; // Adjust as needed for correct orientation
            ring.localScale = initialRingScale;

        }
    }


}
