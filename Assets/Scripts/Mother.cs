using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mother : MonoBehaviour {
    [SerializeField] float warningThreshold = 0.0f;
    [SerializeField] float doubtThreshold = 0.0f;

    [SerializeField] UnityEvent onWarningEvent;
    [SerializeField] UnityEvent onDoubtEvent;
    private void Start() {
        LevelManager.Instance.OnNoiseChanged += OnNoiseChanged;
    }

    private void OnNoiseChanged(float NewNoise) {
        if(NewNoise >= warningThreshold) {
            onWarningEvent.Invoke();
            return;
        }
        if(NewNoise >= doubtThreshold) {
            onDoubtEvent.Invoke();
            return;
        }
    }
}
