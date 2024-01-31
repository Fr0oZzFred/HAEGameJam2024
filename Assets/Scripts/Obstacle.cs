using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] bool destroyableObstacle = false;
    public void MakeNoise(float intensity) {
        LevelManager.Instance.MakeNoise(intensity);
        if (!destroyableObstacle) return;

        GetComponent<Prop>().enabled = false;
        GetComponent<Animator>().SetBool("Broken", true);
    }
}