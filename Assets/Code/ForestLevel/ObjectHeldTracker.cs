using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectHeldTracker : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isHeld;

    void Awake()
    {
        // Get the XRGrabInteractable component attached to this GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the selectEntered and selectExited events
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events when the object is destroyed
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Set isHeld to true when the object is grabbed
        isHeld = true;
        Debug.Log("Object is now held.");
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        // Set isHeld to false when the object is released
        isHeld = false;
        Debug.Log("Object is no longer held.");
    }

    public bool IsHeld()
    {
        // Public method to check if the object is held
        return isHeld;
    }

}

