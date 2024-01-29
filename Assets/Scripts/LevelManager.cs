using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { get; private set; }
    public Player Player => player;
    [SerializeField] Player player;

    private void Awake() {
        if (!Instance) {
            Instance = this;
        }
    }
}
