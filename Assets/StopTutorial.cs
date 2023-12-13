using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTutorial : MonoBehaviour
{
    public GameObject ToSetFalse;
    public GameObject ToSetTrue;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            ToSetFalse.SetActive(false);
            ToSetTrue.SetActive(true);
        }
    }
}
