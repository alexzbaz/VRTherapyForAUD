using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjects : MonoBehaviour
{
    public GameObject child;
    public Vector3 initPos;
    public Quaternion initRotation;
    public Vector3 initScale;
    [SerializeField] private string compareTag;
    public GameObject socket;
    public Vector3 dirToSocket;
    public float rCol;
    public Vector3 centerCol;
    public float rSocket;
    public bool trigger;
    public bool inCoroutine;
    [SerializeField] private Pointsystem pointsystem;

    void Start()
    {
        trigger = true;
        inCoroutine = false;
        centerCol = transform.position + GetComponent<SphereCollider>().center;
        rSocket = socket.GetComponent<SphereCollider>().radius;
        rCol = GetComponent<SphereCollider>().radius;
        initPos = transform.position;
        initRotation = transform.rotation;
        initScale = transform.localScale;
        Debug.Log(initPos);
        dirToSocket = socket.transform.position - centerCol;
    }

    void Update()
    {

        centerCol = transform.position + GetComponent<SphereCollider>().center;
        dirToSocket = socket.transform.position - centerCol;

        //if (transform.position != initPos)
        //{
        //    trigger = true;
        //}
        //else
        //{
        //    trigger = false;
        //}


        //Debug.Log(transform.position);
        // Check if object has a child -> is being held
        if (transform.position != initPos && trigger == true)
        {
            if (transform.childCount == 0)
            {
                //transform.position = initPos;
                //transform.rotation = initRotation;
                if (!inCoroutine)
                {
                    //inCoroutine = true;
                    StartCoroutine(PositionReset());
                    //inCoroutine = false;
                }
            }
            else if (transform.childCount > 0)
            {
                child = transform.GetChild(0).gameObject;
                if (child.name != "Physics RightHand GrabPoint" && child.name != "Physics LeftHand GrabPoint")
                {
                    //Debug.Log("Collission with something else.");
                    //transform.position = initPos;
                    //transform.rotation = initRotation;
                    if (!inCoroutine)
                    {
                        //inCoroutine = true;
                        StartCoroutine(PositionReset());
                        //inCoroutine = false;
                    }

                }
            }
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(compareTag))
		{
            pointsystem.add50Points();
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
        //trigger = true;
        Debug.Log("End Coroutine");
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //    // If the object is dropped (not being held by either left or right hand) and also is not colliding
    //    // with the respective socket -> take it bak to its initial position
    //    if (!other.CompareTag(compareTag))
    //    {
    //        if(transform.childCount == 0)
    //        {
    //            Debug.Log("Collission with something else while object is not held.");
    //            transform.position = initPos;
    //            transform.rotation = initRotation;
    //        }
    //        else if (transform.childCount > 0)
    //        {
    //            child = transform.GetChild(0).gameObject;
    //            if (!other.CompareTag(compareTag) && (child.name != "Physics RightHand GrabPoint" && child.name != "Physics LeftHand GrabPoint"))
    //            {
    //                Debug.Log("Collission with something else.");
    //                transform.position = initPos;
    //                transform.rotation = initRotation;
    //            }
    //        }
    //    }

    //    if(other.CompareTag(compareTag))
    //    {
    //        Debug.Log("Collission with correct socket.");
    //    }

    //    //if (!other.CompareTag(compareTag) && grabbable.transform.childCount == 0) //(child.name != "Physics RightHand GrabPoint" || child.name != "Physics LeftHand GrabPoint"))
    //    //{

    //    //    grabbable.transform.position = initTransform.position;
    //    //    grabbable.transform.rotation = initTransform.rotation;
    //    //    grabbable.transform.localScale = initTransform.localScale;           
    //    //}

    //}
}
