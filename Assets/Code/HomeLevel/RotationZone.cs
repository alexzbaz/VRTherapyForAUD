using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class RotationZone : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshPro textField;
    [SerializeField] private GameObject canvas1;
    [SerializeField] private GameObject canvas2;
    [SerializeField] private Transform teleport1;
    [SerializeField] private Transform teleport2;
    [SerializeField] private GameObject rotTracker;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject cameraOffset;
    [SerializeField] private GameObject xrOrigin;
    [SerializeField] private GameObject xrIntSetup;
    [SerializeField] private GameObject toSetTrue;
    [SerializeField] private GameObject toSetFalse;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float desiredRot1;
    [SerializeField] private float desiredRot2;
    [SerializeField] private float tolerance;
    [SerializeField] private int aligned;
    [SerializeField] private bool rotLocked = false;


    [SerializeField] private Vector3 initRot;
    [SerializeField] private Vector3 actualRot;
    [SerializeField] private float diffRotationY;

    private bool inRotationZone;
    private float diffRotation;
    private TrackedPoseDriver trackedPoseDriverCam;
    private TrackedPoseDriver trackedPoseDriverOrigin;
    [SerializeField] private Vector3 rotMainCameraWorldSpace;

    private void Start()
    {
        //canvas1.SetActive(false);
        //canvas2.SetActive(false);
    }


    private void Update()
    {
        // aktuelle Rotation der Main Camera
        rotMainCameraWorldSpace = mainCamera.transform.rotation.eulerAngles;

        if (playerGameObject != null)
        {
            if (rotLocked)
            {
                // abgekoppelte Rotation, wenn Tracking der Kamera deaktiviert ist
                actualRot = rotTracker.transform.rotation.eulerAngles;

                diffRotationY = NormalizeAngle(actualRot.y) - NormalizeAngle(initRot.y);
                diffRotationY = NormalizeAngle(diffRotationY);

                if (aligned == 1)
                {
                    // Rechtsdrehung
                    if (desiredRot1 == 180)
                    {
                        // desiredRot1 is 180 degrees
                        textField.text = "Um 180 Grad drehen";
                    }
                    else
                    {
                        // desiredRot1 is +90 degrees
                        textField.text = "Um 90 Grad nach rechts drehen";
                    }
                    
                    canvas.SetActive(true);
                    
                     

                    if (diffRotationY >= desiredRot1 - tolerance && diffRotationY <= desiredRot1 + tolerance)
                    {
                        Debug.Log("Teleportation 1");
                        unlockRotation();
                    }
                }

                else if (aligned == 2)
                {
                    // Linksdrehung
                    if (desiredRot2 == 180)
                    {
                        // desiredRot1 is 180 degrees
                        textField.text = "Um 180 Grad drehen";
                    }
                    else
                    {
                        // desiredRot2 is -90 degrees
                        textField.text = "Um 90 Grad nach links drehen";
                    }
                    
                    canvas.SetActive(true);

                    float desiredRot = NormalizeAngle(360 - desiredRot1);
                    Debug.Log(desiredRot);

                    if (diffRotationY >= desiredRot - tolerance && diffRotationY <= desiredRot + tolerance)
                    {
                        Debug.Log("Teleportation 2");
                        unlockRotation();
                    }
                }
            }
            
            
        }
    }

    float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle < 0)
        {
            angle += 360;
        }
            
        return angle;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision");
        if (other.CompareTag("Player")  && !mainCamera.GetComponent<InTeleportation>().inTeleportation)
        {
            Debug.Log("OnTriggerEnter" + name);
            //checkAlignment();
            Debug.Log("Collision with Player");
            //canvas.SetActive(true);
            playerGameObject = other.gameObject;
            //inRotationZone = true;
            
            // Tatsächliche Rotation bei Eintreten in RotArea
            // Sollte bei korrektem Alignment gesetzt werden
            // initRot = rotTracker.transform.rotation.eulerAngles;
            
            //lockRotation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !rotLocked && !mainCamera.GetComponent<InTeleportation>().inTeleportation)
        {
            Debug.Log("OnTriggerStay" + name);
            // if in teleportation bei Player
            aligned = checkAlignment();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //playerinTeleportation = false;
            //initRot = Quaternion.identity;
            rotLocked = false;
            canvas.SetActive(false);

            Debug.Log("OnTriggerExit" + name);
            if(playerGameObject == null)
            {
                mainCamera.GetComponent<InTeleportation>().inTeleportation = false;

            }

            if (mainCamera.GetComponent<InTeleportation>().inTeleportation)
            {
                playerGameObject = null;
            }
            //playerGameObject = null;

        }
    }

    private int checkAlignment() 
    {
        //actualRot = rotTracker.transform.rotation;
        int a = 0;
        //Debug.Log(rotMainCameraWorldSpace.y - (canvas1.transform.rotation).eulerAngles.y);

        if (canvas1 != null && Mathf.Abs(rotMainCameraWorldSpace.y - (canvas1.transform.rotation).eulerAngles.y) <= tolerance)
        {
            Debug.Log("Ausrichtung für Rechtsdrehung");
            // Tatsächliche Rotation bei korrektem alignment
            initRot = rotTracker.transform.rotation.eulerAngles;
            a = 1;
            lockRotation();
        }
        else if (canvas2 != null && Mathf.Abs(rotMainCameraWorldSpace.y - (canvas2.transform.rotation).eulerAngles.y) <= tolerance)
        {
            Debug.Log("Ausrichtung für Linksdrehung");
            // Tatsächliche Rotation bei korrektem alignment
            initRot = rotTracker.transform.rotation.eulerAngles;
            a = 2;
            lockRotation();
        }
        else
        {
            if (!rotLocked) {
                //Debug.Log("Ausrichten");
                // Set the text of the TextMeshProUGUI component
                textField.text = "Bitte ausrichten";
                canvas.SetActive(true);
                a = 0;
            }
            
        }

        return a;
    }

    private void lockRotation()
    {
        
        trackedPoseDriverCam = mainCamera.GetComponent<TrackedPoseDriver>();
        trackedPoseDriverOrigin = xrOrigin.GetComponent<TrackedPoseDriver>();
        trackedPoseDriverCam.trackingType = TrackedPoseDriver.TrackingType.PositionOnly;
        //trackedPoseDriverCam.enabled = false;
        //trackedPoseDriverOrigin.enabled = false;
        rotLocked = true;
    }

    private void unlockRotation()
    {
        //cameraOffset.transform.rotation = Quaternion.Euler(cameraOffset.transform.rotation.eulerAngles + new Vector3(0, desiredRot1, 0));
        trackedPoseDriverCam = mainCamera.GetComponent<TrackedPoseDriver>();
        //trackedPoseDriverOrigin = xrOrigin.GetComponent<TrackedPoseDriver>();



        //toSetFalse.SetActive(false);
        //toSetTrue.SetActive(true);
        canvas.SetActive(false);
        rotLocked = false;
        // teleport

        if (playerGameObject != null)
        {

            if(desiredRot1 == 180)
            {
                // previous
                //float desiredRot180 = NormalizeAngle(NormalizeAngle(cameraOffset.transform.rotation.eulerAngles.y) - NormalizeAngle(teleport1.transform.rotation.eulerAngles.y) - NormalizeAngle(mainCamera.transform.rotation.eulerAngles.y) - 90);
                //Debug.Log(NormalizeAngle(cameraOffset.transform.rotation.eulerAngles.y));
                //Debug.Log(NormalizeAngle(teleport1.transform.rotation.eulerAngles.y));
                //Debug.Log(desiredRot180);
                //mainCamera.GetComponent<InTeleportation>().inTeleportation = true;
                //Quaternion offsetRotation = Quaternion.Euler(0, NormalizeAngle(-desiredRot180), 0);
                //cameraOffset.transform.rotation = offsetRotation;

                // chatgpt
                // Calculate the desired rotation angle for the main camera (teleport1 - 90 degrees)
                float desiredCameraRotation = NormalizeAngle(teleport1.transform.rotation.eulerAngles.y - 90);

                // Get the current rotation of the main camera relative to the camera offset
                float currentCameraRotation = NormalizeAngle(mainCamera.transform.localRotation.eulerAngles.y);

                // Calculate the necessary offset rotation to achieve the desired main camera rotation
                float desiredOffsetRotation = NormalizeAngle(desiredCameraRotation - currentCameraRotation + 180);

                // Log the normalized angles for debugging purposes
                Debug.Log("Teleport1 Rotation: " + NormalizeAngle(teleport1.transform.rotation.eulerAngles.y));
                Debug.Log("Desired Camera Rotation: " + desiredCameraRotation);
                Debug.Log("Current Camera Rotation: " + currentCameraRotation);
                Debug.Log("Desired Offset Rotation: " + desiredOffsetRotation);

                // Set the inTeleportation flag on the InTeleportation component
                mainCamera.GetComponent<InTeleportation>().inTeleportation = true;

                // Calculate the offset rotation
                Quaternion offsetRotation = Quaternion.Euler(0, desiredOffsetRotation, 0);

                // Apply the offset rotation to the camera offset transform
                cameraOffset.transform.rotation = offsetRotation;

                // Berechne die neue Position des cameraOffset
                Vector3 newPosition = teleport1.transform.position - cameraOffset.transform.rotation * mainCamera.transform.localPosition;
                // Retain the original y coordinate
                newPosition.y = cameraOffset.transform.position.y;
                cameraOffset.transform.position = newPosition;

                trackedPoseDriverCam.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
            }

            else
            {
                if (aligned == 1)
                {
                    Debug.Log("Teleportation 1 abgeschlossen");

                    mainCamera.GetComponent<InTeleportation>().inTeleportation = true;
                    Quaternion offsetRotation = Quaternion.Euler(0, NormalizeAngle(-desiredRot1), 0);
                    cameraOffset.transform.rotation *= offsetRotation;


                    // Berechne die neue Position des cameraOffset
                    Vector3 newPosition = teleport1.transform.position - cameraOffset.transform.rotation * mainCamera.transform.localPosition;
                    // Retain the original y coordinate
                    newPosition.y = cameraOffset.transform.position.y;
                    cameraOffset.transform.position = newPosition;

                    trackedPoseDriverCam.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
                }

                else if (aligned == 2)
                {
                    Debug.Log("Teleportation 2 abgeschlossen");

                    mainCamera.GetComponent<InTeleportation>().inTeleportation = true;
                    Quaternion offsetRotation = Quaternion.Euler(0, NormalizeAngle(-desiredRot2), 0);
                    cameraOffset.transform.rotation *= offsetRotation;
                    Debug.Log("CameraOffset Rotation: " + cameraOffset);

                    // Berechne die neue Position des cameraOffset
                    Vector3 newPosition = teleport2.transform.position - cameraOffset.transform.rotation * mainCamera.transform.localPosition;
                    // Retain the original y coordinate
                    newPosition.y = cameraOffset.transform.position.y;
                    cameraOffset.transform.position = newPosition;

                    trackedPoseDriverCam.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
                }
            }
        } 
    }
}
