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
            Check();
            return;
        }
        if(NewNoise >= doubtThreshold) {
            onDoubtEvent.Invoke();
            float r = UnityEngine.Random.Range(0.0f,100.0f);
            if (r >= 50.0f) Check();
            return;
        }
    }

    void Check() {
        if (LevelManager.Instance.Player.CarriedItem &&
            LevelManager.Instance.Player.IsVisible) {
            Debug.Log("Lose");
        }
    }
}
