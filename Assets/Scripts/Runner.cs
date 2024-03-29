using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * The sprite behaviour for our hero
 * Will follow the mouse, and check collisions
 */
public class Runner : Agent
{
    // Start is called before the first frame update
    AudioSource SoundSource;
    public AudioClip EatSound;
    public AudioClip MothSound;
    protected override void Start()
    {
        base.Start();
        SetupSound();
    }

    // Update is called once per frame
    protected override void Update()
    {
        MoveToCursor();
        LookAtCursor();
        base.Update();
    }

    void SetupSound()
    {
        SoundSource = gameObject.GetComponent<AudioSource>();
    }

    void PlayEatSound()
    {
        if (SoundSource != null && EatSound != null)
        {
            SoundSource.PlayOneShot(EatSound, 0.5f);
        }
    }

    void PlayMothHitSound()
    {
        if (SoundSource != null && MothSound != null)
        {
            SoundSource.PlayOneShot(MothSound, 0.5f);
        }
    }

    /*
     * Moves this object toward the cursor
     */
    void MoveToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(mousePos); // Position of the cursor in the world
        TargetPosition = new Vector3(WorldPos.x, WorldPos.y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Food")
        {
            PlayEatSound();
            gameObject.SendMessageUpwards("AteFood", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(collision.gameObject);            
        }
        else if (collision.gameObject.tag == "Moth")
        {
            PlayMothHitSound();
            gameObject.SendMessageUpwards("HitMoth", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(collision.gameObject);            
        };
    }

    /*
     * We'll use the score broadcast to increase our glow size
     */
    public void SetScoreText(float score)
    {
        Transform tr = gameObject.transform.Find("Glow");
        if (tr != null)
        {
            float TScore = Mathf.Max(0, score);
            tr.localScale = new Vector3(TScore, TScore, 1);
        }
    }
}
