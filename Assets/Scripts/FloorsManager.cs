using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Floor {
    Ground = 0,
    Table = 1
}

public class FloorsManager : MonoBehaviour {
    public FloorsManager Instance { get; private set; }
    [SerializeField] GameObject ground;
    [SerializeField] GameObject table;
    private void Awake() {
        Instance = this;
        ChangeFloor(Floor.Ground);
    }

    public void ChangeFloor(Floor newFloor) {
        ground.SetActive(newFloor == Floor.Ground);
        table.SetActive(newFloor == Floor.Table);
    }
    public void ChangeFloor(int enumIdx) {
        ChangeFloor((Floor)enumIdx);
    }
}
