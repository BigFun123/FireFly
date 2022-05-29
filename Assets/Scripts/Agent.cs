using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * Base class for all agents in the game.
     * Agents approach a target at a speed
     */
    public class Agent : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        public Vector3 TargetPosition = Vector3.zero;
        public float Speed = 1f;
        // Use this for initialization
        protected virtual void Start()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            MoveToTarget();       
        }

        /**
         * Moves this agent toward the target by the speed
         */
        void MoveToTarget()
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * Speed);
        }

        /**
         * Calculate distance to the target in screen units         
         */
        protected float DistanceToTarget()
        {
            return Vector3.Distance(transform.position, TargetPosition);
        }

        /**
          * Adjusts scale, orientation to look at the cursor
          * */
        protected void LookAtCursor()
        {
            spriteRenderer.flipX = transform.position.x < TargetPosition.x;
        }
    }
}