using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance { get; private set; }
    public Player Player => player;
    [SerializeField] Player player;

    public float Noise => noise;
    float noise;

    private void Awake() {
        //Careful => Will replace old Level Instance
        Instance = this;
    }

    private void Start() {
        StartCoroutine(ReduceNoise(10.0f, 5.0f));
    }

    public void MakeNoise(float Addnoise) {
        noise += Addnoise;
        noise = Mathf.Clamp(noise, 0.0f, 100.0f);
    }

    IEnumerator ReduceNoise(float value, float delay) {
        MakeNoise(-value);
        if (delay <= 0) yield break;


        yield return new WaitForSeconds(delay);
        StartCoroutine(ReduceNoise(value, delay));
    }
}
