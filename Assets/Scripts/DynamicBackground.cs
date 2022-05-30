using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A background component that moves inversely to the mouse, creating the illusion of a bigger playing field
 */
public class DynamicBackground : MonoBehaviour
{
    public float Amount = 0.1f;
    public Vector3 Bounds = new Vector3(2, 1, 0);
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
        WorldPos.x = Mathf.Clamp(WorldPos.x, -Bounds.x, Bounds.x);
        WorldPos.y = Mathf.Clamp(WorldPos.y, -Bounds.y, Bounds.y);

        transform.position = Vector3.Lerp(transform.position, new Vector3(-WorldPos.x, -WorldPos.y, 0), Time.deltaTime * Amount);
    }
}
