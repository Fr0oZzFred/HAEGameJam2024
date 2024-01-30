using UnityEngine;

public class Obstacle : MonoBehaviour {
    public void MakeNoise(float intensity) {
        LevelManager.Instance.MakeNoise(intensity);
    }
}