using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DigitalPenguin.Unity.Gating
{
    [AddComponentMenu("AutoMove")]
    public class AutoMove : MonoBehaviour
    {

        public Vector3 direction;
        public float speed = 1.0f;
        public bool startImmediately = true;

        [Header("Collision Events")]
        public UnityEvent onCollisionEnter;
        public UnityEvent onCollisionExit;
        public string onCollisionTag;

        private bool mStarted = false;


        public void StartMove()
        {
            mStarted = true;
        }

        public void PauseMove()
        {
            mStarted = false;
        }

        public void SetDirection(Vector3 newDirection)
        {
            if (newDirection != null)
            {
                this.direction = newDirection;
            }
        }

        public void SetSpeed(float newSpeed)
        {
            this.speed = newSpeed;
        }

        void Start()
        {
            if (startImmediately)
            {
                StartMove();
            }
        }

        
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            if (mStarted)
            {
                Vector3 moveDelta = direction * speed * Time.deltaTime;
                this.transform.position = this.transform.position + moveDelta;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!HasTag() || other.gameObject.CompareTag(onCollisionTag))
            {
                onCollisionEnter?.Invoke();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (!HasTag() || other.gameObject.CompareTag(onCollisionTag))
            {
                onCollisionEnter?.Invoke();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (!HasTag() || other.gameObject.CompareTag(onCollisionTag))
            {
                onCollisionExit?.Invoke();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (!HasTag() || other.gameObject.CompareTag(onCollisionTag))
            {
                onCollisionExit?.Invoke();
            }
        }

        private bool HasTag()
        {
            return onCollisionTag != null && onCollisionTag.Length > 0;
        }
    }
}