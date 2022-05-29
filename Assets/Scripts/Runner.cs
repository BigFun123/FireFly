using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * The sprite behaviour for running away 
 */
public class Runner : Agent
{
    [SerializeField] SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        MoveToCursor();
        LookAtCursor();
        base.Update();
    }

    /**
     * Moves this object toward the cursor
     * */
    void MoveToCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(mousePos); // Position of the cursor in the world
        TargetPosition = new Vector3(WorldPos.x, WorldPos.y, 0);
    }

    /**
     * Adjusts scale, orientation to look at the cursor
     * */
    void LookAtCursor()
    {
        spriteRenderer.flipX = transform.position.x < TargetPosition.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Food")
        {
            gameObject.SendMessageUpwards("AteFood", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Moth")
        {
            gameObject.SendMessageUpwards("HitMoth", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(collision.gameObject);
        };
    }
}
