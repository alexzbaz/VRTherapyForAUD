using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask npcLayer;
    [SerializeField] private GameObject entrance;

    [SerializeField] private bool rightDoor; // Set in Editor
    private Vector3 startRotation;
    private Quaternion endRotationRight;
    private Quaternion endRotationLeft;
    private bool doorOpened = false;

    private void Start()
    {
        startRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] doorColliders = Physics.OverlapSphere(transform.position, 2f, playerLayer);
        Collider[] npcColliders = Physics.OverlapSphere(transform.position, 1.5f, npcLayer);

        if (doorColliders.Length > 0 || npcColliders.Length > 0)
        {
            if (!doorOpened)
            {
                doorOpened = true;
                if (rightDoor)
                {
                    entrance.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
                else
                {
                    entrance.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
            }
        }
        else
        {
            if (doorOpened)
            {
                entrance.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                doorOpened = false;
            }
        }
    }
}
