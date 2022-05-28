using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    // The speed this runner will approach the cursor position
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMouse();
    }

    /**
     * Moves this object toward the cursor
     * */
    void MoveToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;

        Vector3 MouseWorldpos = Camera.main.ScreenToWorldPoint(mousePos); // Position of the cursor in the world
        transform.position = Vector3.Lerp(transform.position, MouseWorldpos, Time.deltaTime * Speed);
    }
}
