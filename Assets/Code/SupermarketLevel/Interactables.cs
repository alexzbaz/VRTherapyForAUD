using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public GameObject child;
    public Vector3 initPos;
    public Quaternion initRotation;
    public Vector3 initScale;
    public string compareTag;
    public Ray ray;
    public float rSocket;
    public bool trigger;
    public bool inCoroutine;

    void Start()
    {
        trigger = true;
        inCoroutine = false;
        initPos = transform.position;
        initRotation = transform.rotation;
        initScale = transform.localScale;
        Debug.Log(initPos);
    }

    void Update()
    {
        if (transform.position != initPos && trigger == true)
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            trigger = false;
            Debug.Log("Inside Collider of Socket");
        }

        if (other.CompareTag("Inventory"))
        {
            trigger = false;
            Debug.Log("Inside Collider of Socket");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(compareTag))
        {
            trigger = true;
            Debug.Log("Outside Collider of Socket");
        }

        if (other.CompareTag("Inventory"))
        {
            trigger = true;
            Debug.Log("Inside Collider of Socket");
        }
    }

    IEnumerator PositionReset()
    {
        Debug.Log("Start Coroutine");
        inCoroutine = true;
        yield return new WaitForSeconds(3);
        transform.position = initPos;
        transform.rotation = initRotation;
        transform.localScale = initScale;
        inCoroutine = false;
        Debug.Log("End Coroutine");
    }
}
