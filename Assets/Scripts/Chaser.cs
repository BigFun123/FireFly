using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Runner Target;
    public float Speed = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 TargetVector = CalculateTargetVector();        
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    Vector3 CalculateTargetVector()
    {
        Vector3 v = transform.position - Target.transform.position;
        v.Normalize();
        Debug.Log(v);
        return v;
    }
}
