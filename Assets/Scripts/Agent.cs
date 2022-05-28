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

        public Vector3 TargetPosition = Vector3.zero;
        public float Speed = 1f;
        // Use this for initialization
        void Start()
        {
            //
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
    }
}