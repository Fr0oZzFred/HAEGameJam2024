using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance { get; private set; }
    public Player Player => player;
    public Objective Objective => objective;
    [SerializeField] Player player;
    [SerializeField] Objective objective;

    public float Noise => noise;
    float noise;
    public delegate void OnNoiseChangedDelegate(float NewNoise);
    public OnNoiseChangedDelegate OnNoiseChanged;

    private void Awake() {
        //Careful => Will replace old Level Instance
        Instance = this;
    }

    private void Start() {
        StartCoroutine(ReduceNoise(2.0f, 1.0f));
        objective.OnGiveFood += OnGiveFood;
    }

    private void OnGiveFood(FoodType foodType) {
        if(foodType == FoodType.LollipopB) {
            GameManager.Instance.ChangeGameState(GameStates.GameOverWin);
            return;
        }

        Debug.Log("add score");
        objective.SetAskedfood(foodType + 1);
    }

    public void MakeNoise(float Addnoise) {
        noise += Addnoise;
        noise = Mathf.Clamp(noise, 0.0f, 100.0f);
        OnNoiseChanged.Invoke(noise);
    }

    IEnumerator ReduceNoise(float value, float delay) {
        MakeNoise(-value);
        if (delay <= 0) yield break;


        yield return new WaitForSeconds(delay);
        StartCoroutine(ReduceNoise(value, delay));
    }
}
