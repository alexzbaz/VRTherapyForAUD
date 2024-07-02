using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will exist 3 times and is used for controlling the specific UIs.

public class InitInteraction : MonoBehaviour
{
    [SerializeField] private Canvas ui;

    private void Start()
    {
        ui.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Bei reinlaufen Y_scale auf 0.2 ändern
            transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
            ui.enabled = true;
        }
    }

}
