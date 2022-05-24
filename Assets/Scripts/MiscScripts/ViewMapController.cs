using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMapController : MonoBehaviour
{
    private Renderer renderer;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    private void OnApplicationQuit()
    {
        renderer.enabled = true;
    }
}
