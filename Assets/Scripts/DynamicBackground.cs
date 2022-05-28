using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(mousePos); // Position of the cursor in the world
        transform.position = Vector3.Lerp(transform.position, new Vector3(-WorldPos.x, WorldPos.y, WorldPos.z), Time.deltaTime * 0.01f);
    }
}
