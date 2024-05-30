using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject rotTracker;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cameraOffset;
    [SerializeField] private GameObject toSetTrue;
    [SerializeField] private GameObject toSetFalse;
    [SerializeField] private float desiredRot;


    private Quaternion initRot;
    private Quaternion actualRot;

    private bool inRotationZone;
    private float diffRotation;
    private GameObject playerGameObject;
    private TrackedPoseDriver trackedPoseDriver;
    

    private void Update()
    {
        if(playerGameObject != null)
        {
            actualRot = rotTracker.transform.rotation;
            diffRotation = Quaternion.Angle(initRot, actualRot);

            if (diffRotation >= desiredRot && inRotationZone)
            {
                unlockRotation();
            }
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision with Player");
            canvas.SetActive(true); 
            playerGameObject = other.gameObject;
            inRotationZone = true;
            initRot = rotTracker.transform.rotation;
            lockRotation();
        }
    }

    private void lockRotation()
    {
        trackedPoseDriver = mainCamera.GetComponent<TrackedPoseDriver>();
        trackedPoseDriver.trackingType = TrackedPoseDriver.TrackingType.PositionOnly;
    }

    private void unlockRotation()
    {
        trackedPoseDriver = mainCamera.GetComponent<TrackedPoseDriver>();
        trackedPoseDriver.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        cameraOffset.transform.rotation = Quaternion.Euler(cameraOffset.transform.rotation.eulerAngles + new Vector3(0, desiredRot, 0));

        toSetFalse.SetActive(false);
        toSetTrue.SetActive(true);
        canvas.SetActive(false);
    }
}
