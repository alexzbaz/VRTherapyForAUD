//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Interactables_Supermarket : MonoBehaviour
//{
//    // Object's position
//    public GameObject child;
//    [SerializeField] private Vector3 initPos;
//    [SerializeField] private Quaternion initRotation;
//    [SerializeField] private Vector3 initScale;

//    // Placing object
//    //[SerializeField] private string compareTag;
//    //[SerializeField] private GameObject socket;

//    // [SerializeField] private Vector3 dirToSocket;  --> Diese 4 Variablen werden laut Visual Studio nicht ausgelesen,
//    // [SerializeField] private float rCol;           --> also werden sie nicht genutzt. Können die raus? Hab sie auch unten auskommentiert
//    // [SerializeField] private Vector3 centerCol;
//    // [SerializeField] private float rSocket;

//    // Grabbing object
//    [SerializeField] private bool trigger;
//    [SerializeField] private bool inCoroutine;

//    // Pointsystem
//    //[SerializeField] private Pointsystem pointsystem;

//    void Start()
//    {
//        trigger = false;
//        inCoroutine = false;
//        StartCoroutine(InitPosition());
//        // centerCol = transform.position + GetComponent<SphereCollider>().center;
//        // rSocket = socket.GetComponent<SphereCollider>().radius;
//        // rCol = GetComponent<SphereCollider>().radius;
//        //initPos = transform.position;
//        //initRotation = transform.rotation;
//        //initScale = transform.localScale;
//        // dirToSocket = socket.transform.position - centerCol;
//    }

//    void Update()
//    {
//        // centerCol = transform.position + GetComponent<SphereCollider>().center;
//        // dirToSocket = socket.transform.position - centerCol;

//        // Check if object has a child -> is being held
//        if (transform.position != initPos && trigger == true)
//        {
//            if (transform.childCount == 0)
//            {
//                //transform.position = initPos;
//                //transform.rotation = initRotation;
//                if (!inCoroutine)
//                {
//                    //inCoroutine = true;
//                    StartCoroutine(PositionReset());
//                    //inCoroutine = false;
//                }
//            }
//            else if (transform.childCount > 0)
//            {
//                child = transform.GetChild(0).gameObject;
//                if (child.name != "Physics RightHand GrabPoint" && child.name != "Physics LeftHand GrabPoint")
//                {
//                    //Debug.Log("Collission with something else.");
//                    //transform.position = initPos;
//                    //transform.rotation = initRotation;
//                    if (!inCoroutine)
//                    {
//                        //inCoroutine = true;
//                        StartCoroutine(PositionReset());
//                        //inCoroutine = false;
//                    }

//                }
//            }
//        }
//    }

//    //private void OnTriggerEnter(Collider other)
//    //{
//    //    if (other.CompareTag(compareTag) || other.CompareTag("Inventory"))
//    //    {
//    //        pointsystem.add50Points();
//    //    }
//    //}

//    private void OnTriggerStay(Collider other)
//    {
//        //if (other.CompareTag(compareTag))
//        //{
//        //    trigger = false;
//        //    Debug.Log("Inside Collider of Socket");
//        //}

//        if (other.CompareTag("Inventory"))
//        {
//            trigger = false;
//            //Debug.Log("Inside Collider of Socket");
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //if (other.CompareTag(compareTag))
//        //{
//        //    trigger = true;
//        //    Debug.Log("Outside Collider of Socket");
//        //}

//        if (other.CompareTag("Inventory"))
//        {
//            trigger = true;
//            //Debug.Log("Inside Collider of Socket");
//        }
//    }

//    IEnumerator InitPosition()
//    {
//        yield return new WaitForSeconds(1);
//        initPos = transform.position;
//        initRotation = transform.rotation;
//        initScale = transform.localScale;
//        trigger = true;
//    }


//    IEnumerator PositionReset()
//    {
//        //Debug.Log("Start Coroutine");
//        inCoroutine = true;
//        yield return new WaitForSeconds(3);
//        transform.position = initPos;
//        transform.rotation = initRotation;
//        transform.localScale = initScale;
//        inCoroutine = false;
//        //trigger = true;
//        //Debug.Log("End Coroutine");
//    }

//    //private void OnTriggerEnter(Collider other)
//    //{

//    //    // If the object is dropped (not being held by either left or right hand) and also is not colliding
//    //    // with the respective socket -> take it bak to its initial position
//    //    if (!other.CompareTag(compareTag))
//    //    {
//    //        if(transform.childCount == 0)
//    //        {
//    //            Debug.Log("Collission with something else while object is not held.");
//    //            transform.position = initPos;
//    //            transform.rotation = initRotation;
//    //        }
//    //        else if (transform.childCount > 0)
//    //        {
//    //            child = transform.GetChild(0).gameObject;
//    //            if (!other.CompareTag(compareTag) && (child.name != "Physics RightHand GrabPoint" && child.name != "Physics LeftHand GrabPoint"))
//    //            {
//    //                Debug.Log("Collission with something else.");
//    //                transform.position = initPos;
//    //                transform.rotation = initRotation;
//    //            }
//    //        }
//    //    }

//    //    if(other.CompareTag(compareTag))
//    //    {
//    //        Debug.Log("Collission with correct socket.");
//    //    }

//    //    //if (!other.CompareTag(compareTag) && grabbable.transform.childCount == 0) //(child.name != "Physics RightHand GrabPoint" || child.name != "Physics LeftHand GrabPoint"))
//    //    //{

//    //    //    grabbable.transform.position = initTransform.position;
//    //    //    grabbable.transform.rotation = initTransform.rotation;
//    //    //    grabbable.transform.localScale = initTransform.localScale;           
//    //    //}

//    //}
//}
