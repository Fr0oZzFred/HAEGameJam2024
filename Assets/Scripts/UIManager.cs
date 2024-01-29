using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] Slider NoiseGauge;

    private void Awake() {
        if (!Instance)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update() {
        if (LevelManager.Instance)
            NoiseGauge.value = LevelManager.Instance.Noise * 0.01f;
    }
}
