using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DigitalPenguin.Unity.Timer
{
    [AddComponentMenu("UniTimer")]
    public class UniTimer : MonoBehaviour
    {
        public enum TimerAction
        {
            [InspectorName("Load Scene")]
            LOADSCENE,
            [InspectorName("Toggle GameObject")]
            TOGGLE_GAMEOBJECT,
            [InspectorName("Animation Trigger")]
            ANIMATIONTRIGGER,
            [InspectorName("Unity Event")]
            UNITY_EVENT
        }

        [Header("Timer Settings")]
        public float timeSeconds;
        public TimerAction action;

        //
        // Optional Fields
        //

        public string sceneName;
        public GameObject toggleObject;
        public bool activate;
        public string animationTriggerName;
        public UnityEvent unityEvent;

        [Header("Options")]
        public bool startOnAwake = true;
        public bool repeating = false;
        public bool destroyOnCompletion = false;

        //
        // Private Fields
        //

        private float mTimer;
        public float Timer { get => this.mTimer; }

        private bool mStarted = false;

        private void Awake()
        {
            if (action == TimerAction.TOGGLE_GAMEOBJECT && toggleObject == null)
            {
                Debug.LogWarning("No GameObject set to activate/deactivate.");
            }
            else if (action == TimerAction.ANIMATIONTRIGGER && (animationTriggerName == null || animationTriggerName.Length == 0))
            {
                Debug.LogWarning("No Trigger name set for Animator");
            }
            else if (action == TimerAction.LOADSCENE && (sceneName == null || sceneName.Length == 0))
            {
                Debug.LogWarning("No Scene name has been defined");
            }
        }

        void Start()
        {
            if (startOnAwake)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            mTimer = timeSeconds;
            mStarted = true;
        }

        public void StartTimer(float durationSeconds)
        {
            this.timeSeconds = durationSeconds;
            this.StartTimer();
        }

        void Update()
        {
            if (mStarted)
            {
                if (mTimer > 0)
                {
                    // End not yet reached
                    mTimer = Mathf.Max(0, mTimer - Time.deltaTime);
                }
                else
                {
                    // Time's up!
                    mStarted = false;
                    DoAction();
                }
            }
        }

        private void DoAction()
        {
            if (action == TimerAction.TOGGLE_GAMEOBJECT && this.toggleObject != null)
            {
                toggleObject.SetActive(activate);
                OnTimerEnd();
            }
            else if (action == TimerAction.LOADSCENE && this.sceneName != null)
            {
                SceneManager.LoadScene(sceneName);
                OnTimerEnd();
            }
            else if (action == TimerAction.ANIMATIONTRIGGER && this.animationTriggerName != null)
            {
                Animator animator = GetComponent<Animator>();
                if (animator == null)
                {
                    Debug.LogWarning("No Animator found.");
                    return;
                }
                animator.SetTrigger(animationTriggerName);
                OnTimerEnd();
            }
            else if (action == TimerAction.UNITY_EVENT)
            {
                unityEvent?.Invoke();
                OnTimerEnd();
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        private void OnTimerEnd()
        {
            if (repeating)
            {
                StartTimer();
            }
            else if (destroyOnCompletion)
            {
                Destroy(this.gameObject);
            }
        }
    }
}