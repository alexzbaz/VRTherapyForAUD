using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjects : MonoBehaviour
{
    // Object's position
    public GameObject child;
    private Vector3 initPos;
    private Quaternion initRotation;
    private Vector3 initScale;

    // Placing object
    [SerializeField] private string compareTag;
    [SerializeField] private GameObject socket;

    // Grabbing object
    [SerializeField] private bool resetTrigger;
    [SerializeField] private bool inCoroutine;

    // Pointsystem
    [SerializeField] private Pointsystem pointsystem;

    void Start()
    {
        resetTrigger = false;
        inCoroutine = false;
        StartCoroutine(InitPosition());
    }

    void Update()
    {
        // Check if object has a child -> is being held
        if (transform.position != initPos && resetTrigger == true)
        {
            if (transform.childCount == 0)
            {
                if (!inCoroutine)
                {
                    StartCoroutine(PositionReset());
                }
            }
            else if (transform.childCount > 0)
            {
                child = transform.GetChild(0).gameObject;
                if (child.name != "Physics RightHand GrabPoint" && child.name != "Physics LeftHand GrabPoint")
                {
                    if (!inCoroutine)
                    {
                        StartCoroutine(PositionReset());
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(compareTag) || other.CompareTag("Inventory"))
        {
            pointsystem.add50Points();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            resetTrigger = false;
            //Debug.Log("Inside Collider of Socket");
        }

        if (other.CompareTag("Inventory"))
        {
            resetTrigger = false;
            //Debug.Log("Inside Collider of Socket");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            resetTrigger = true;
            //Debug.Log("Outside Collider of Socket");
        }

        if (other.CompareTag("Inventory"))
        {
            resetTrigger = true;
            //Debug.Log("Inside Collider of Socket");
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
        //Debug.Log("Start Coroutine");
        inCoroutine = true;
        yield return new WaitForSeconds(3);
        transform.position = initPos;
        transform.rotation = initRotation;
        transform.localScale = initScale;
        inCoroutine = false;
        //Debug.Log("End Coroutine");
    }

}
