using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will exist 3 times and is used for controlling the specific UIs.

public class InitInteraction : MonoBehaviour
{
    [SerializeField] private Canvas ui;
    private int interactionNumber;

    private void Start()
    {
        interactionNumber = 1;
        ui.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Start Dialogue");
            ui.enabled = true;
        }
    }

    public void disableUi()
    {
        ui.enabled = false;
    }
}
