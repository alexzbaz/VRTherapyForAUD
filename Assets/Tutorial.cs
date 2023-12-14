using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject toSetTrue;
    public GameObject toSetFalse;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            toSetFalse.SetActive(false);
            toSetTrue.SetActive(true);
        }
    }
}
