using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float smoothing;

        // Use this for initialization
        private void Start()
        {
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;
        }


        // Update is called once per frame
        private void LateUpdate()
        {
            if ((Vector2)transform.position != (Vector2)target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
}
