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
    protected override void Start()
    {
        base.Start();
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
        LookAtCursor();
        base.Update();
    }
  
    /**
     * Increase volume as chaser approaches target to create some tension
     * */
    void UpdateSound()
    {
        if (sound != null)
        {   
            float TargetVolume = 1 - DistanceToTarget() * VolumeCoefficient;
            sound.volume = Mathf.Clamp(TargetVolume, 0, 1);            
        }
    }
}
