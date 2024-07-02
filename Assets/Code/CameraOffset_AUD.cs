using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CameraOffset_AUD : MonoBehaviour
{

    [SerializeField] private GameObject border_start;
    [SerializeField] private GameObject border1;
    [SerializeField] private GameObject border2;

    [SerializeField] private float mainCameraRotY;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");

        float border_rot_y = border_start.transform.rotation.eulerAngles.y; 
        Vector3 border_pos = border_start.transform.position;

        mainCameraRotY = mainCamera.transform.rotation.eulerAngles.y;

        Quaternion offsetRotation = Quaternion.Euler(0, border_rot_y + mainCameraRotY, 0);
        transform.rotation *= offsetRotation;

        Vector3 des_pos = border_pos + border_start.transform.right * (-border1.transform.localScale.x * 0.5f - 1) + border_start.transform.forward * (-border2.transform.localScale.x * 0.5f - 1);
        transform.position = des_pos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
