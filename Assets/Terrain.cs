using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TerrainCollider>().enabled = false;
        GetComponent<TerrainCollider>().enabled = true;
    }
}
