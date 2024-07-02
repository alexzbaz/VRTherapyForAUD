using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] private string compareTag;
    [SerializeField] private GameObject attachPoint;
    [SerializeField] private GameObject ring;

    private ObjectHeldTracker heldTracker;
    private Vector3 initialRingScale;



    // Start is called before the first frame update
    void Start()
    {
        initialRingScale = ring.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            Debug.Log("Inside");
            ring.transform.localScale *= 1.5f;

            // Get the ObjectHeldTracker component from the colliding object
            heldTracker = other.GetComponent<ObjectHeldTracker>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Some Collision");
        if (other.CompareTag(compareTag))
        {
            ring.transform.localScale = initialRingScale;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(compareTag) && !heldTracker.IsHeld())
        {
            if (other.CompareTag("Tutorial_Object"))
            {
                other.transform.position = attachPoint.transform.position; // Adjust as needed for correct placement
                
                other.transform.rotation = other.GetComponent<TutorialObjects>().initRotation;
            }

            else
            {
                other.gameObject.SetActive(false);
                
            }

            ring.transform.localScale = initialRingScale;

        }
    }


}
