using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    /**
     * Adds a subtle bobbing to the position
     */
    public class BobAnimation : MonoBehaviour
    {
        public float Strength = 0.001f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(0, Mathf.Sin(Time.timeSinceLevelLoad) * Strength, 0);
        }
    }
}