using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum MotherState {
    Idle = 0,
    Doubt = 1,
    Warning = 2
}
public class Mother : MonoBehaviour {
    [SerializeField] float warningThreshold = 0.0f;
    [SerializeField] float doubtThreshold = 0.0f;

    [SerializeField] UnityEvent onIdleEvent;
    [SerializeField] UnityEvent onDoubtEvent;
    [SerializeField] UnityEvent onWarningEvent;

    MotherState curState;
    Animator animator;
    private void Start() {
        LevelManager.Instance.OnNoiseChanged += OnNoiseChanged;
        animator = GetComponent<Animator>();
    }

    private void OnNoiseChanged(float NewNoise) {
        if (NewNoise >= warningThreshold) {
            if (curState == MotherState.Warning) return;
            StartCoroutine(ChangeState(MotherState.Warning));
            return;
        }
        if(NewNoise >= doubtThreshold) {
            if (curState == MotherState.Doubt) return;
            StartCoroutine(ChangeState(MotherState.Doubt));
            return;
        }
        if (curState == MotherState.Idle) return;
        StartCoroutine(ChangeState(MotherState.Idle));
    }

    bool changeStateCoroutineRunning = false;
    IEnumerator ChangeState(MotherState state) {
        if (changeStateCoroutineRunning) yield break;
        changeStateCoroutineRunning = true;
        animator.SetBool("Warning", state == MotherState.Warning);
        animator.SetBool("Doubt", state == MotherState.Doubt);
        curState = state;

        bool doubtToWarning = false;
        switch (state) {
            case MotherState.Idle:
                onIdleEvent.Invoke();
                break;
            case MotherState.Doubt:
                onDoubtEvent.Invoke();
                float r = UnityEngine.Random.Range(0.0f, 100.0f);
                doubtToWarning = r >= 80.0f;
                break;
            case MotherState.Warning:
                onWarningEvent.Invoke();
                CheckPlayer();
                break;
        }
        yield return new WaitForSeconds(5.0f);
        changeStateCoroutineRunning = false;
        if (doubtToWarning)
            StartCoroutine(ChangeState(MotherState.Warning));
    }

    void CheckPlayer() {
        Debug.Log("Check");
        LevelManager.Instance.MakeNoise(-100.0f);
        if (LevelManager.Instance.Player.CarriedItem &&
            LevelManager.Instance.Player.IsVisible) {
            Debug.Log("Lose");
        }
    }
}