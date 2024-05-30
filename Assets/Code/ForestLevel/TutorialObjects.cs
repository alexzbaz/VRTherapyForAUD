using UnityEngine;
using System.Collections;

public class TutorialObjects : MonoBehaviour
{
    public string compareTag;
    private ObjectHeldTracker heldTracker;
    private bool inSocket = false;
    private Vector3 initPos;
    public Quaternion initRotation;
    private Vector3 initScale;
    private bool resetTrigger = false;
    private Coroutine resetCoroutine;

    void Start()
    {
        StartCoroutine(InitPosition());
        heldTracker = GetComponent<ObjectHeldTracker>();
    }

    void Update()
    {
        if (!heldTracker.IsHeld() && !inSocket && resetCoroutine == null)
        {
            resetCoroutine = StartCoroutine(PositionReset());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(compareTag) || other.CompareTag("Inventory"))
        {
            inSocket = true;
            // pointsystem.add50Points();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            inSocket = true;

            // Cancel the reset coroutine if the object is inside the socket
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
                resetCoroutine = null;
            }
        }

        if (other.CompareTag("Inventory"))
        {
            // In case you want to reset when inside the inventory, you can set resetTrigger to true here
            inSocket = true;

            // Cancel the reset coroutine if the object is inside the socket
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
                resetCoroutine = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            inSocket = false;
        }

        if (other.CompareTag("Inventory"))
        {
            inSocket = false;
            // In case you want to reset when exiting the inventory, you can set resetTrigger to true here
        }
    }

    IEnumerator InitPosition()
    {
        yield return new WaitForSeconds(1);
        initPos = transform.position;
        initRotation = transform.rotation;
        initScale = transform.localScale;
        resetTrigger = true;
    }

    IEnumerator PositionReset()
    {
        yield return new WaitForSeconds(3);
        transform.position = initPos;
        transform.rotation = initRotation;
        transform.localScale = initScale;
        resetTrigger = false;
        resetCoroutine = null;
    }
}
