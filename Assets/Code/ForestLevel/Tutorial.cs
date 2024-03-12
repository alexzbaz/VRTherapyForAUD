using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject toSetTrue;
    [SerializeField] private GameObject toSetFalse;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            toSetFalse.SetActive(false);
            toSetTrue.SetActive(true);
        }
    }
}
