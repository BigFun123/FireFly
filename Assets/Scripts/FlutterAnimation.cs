using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class FlutterAnimation : MonoBehaviour
    {
        public float Strength = 0.01f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(Mathf.Sin(Time.timeSinceLevelLoad) * Strength, 0, 0);
            float flap = Mathf.Max(0.5f, 0.2f + Mathf.Sin(Time.timeSinceLevelLoad * 35f) * 0.5f);
            transform.localScale = new Vector3(flap, 0.5f, 0.5f);
        }
    }
}