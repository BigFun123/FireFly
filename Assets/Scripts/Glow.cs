using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Flips and positions the hero's glow
 * Simpler than implementing a solution in the GUI because the scale increases, but not the pivot offset
 */
public class Glow : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public Vector3 Offset = new Vector3(0.4f, -0.3f, 0);
    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    }

    /**
     * Flip and position the glow
     */
    public void Flip(bool direction)
    {
        spriteRenderer.flipX = direction;                
        transform.localPosition = new Vector3(spriteRenderer.flipX ? -Offset.x : Offset.x, Offset.y, 0);
    }
}
