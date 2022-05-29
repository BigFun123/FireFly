using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Agent
{
    public Runner TargetObject;
    public Vector3 RandomOffset;
    public float VolumeCoefficient = 0.1f; // ratio of distance to volume
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        CalculateOffset();
        SetupSound();
    }

    void SetupSound()
    {
        sound = gameObject.GetComponent<AudioSource>();
        if (sound != null)
        {
            sound.Play();
            sound.loop = true;
        }
    }

    /*
     * Prevent chasers all ending up in the same place by creating a unique offset for each one
     * */
    void CalculateOffset()
    {
        RandomOffset = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
    }

    // Update is called once per frame
    protected override void Update()
    {
        TargetPosition = TargetObject.transform.position + RandomOffset;
        //todo: choose better sprites for each angle
        UpdateSound();
        base.Update();
    }

    /**
     * TODO: Orient sprite to target
     * */
    Vector3 CalculateTargetVector()
    {
        Vector3 v = transform.position - TargetObject.transform.position;
        v.Normalize();        
        return v;
    }

    /**
     * Increase volume as chaser approaches target to create some tension
     * */
    void UpdateSound()
    {
        if (sound != null)
        {
            // Debug.Log(DistanceToTarget() * VolumeCoefficient);
            float TargetVolume = 1 - DistanceToTarget() * VolumeCoefficient;
            sound.volume = Mathf.Clamp(TargetVolume, 0, 1);            
        }
    }
}
