using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    [SerializeField] int loadSceneIdx = -1;
    private void Awake() {
        if (GameManager.Instance) {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        //Check if need to load scene
        if (loadSceneIdx >= 0) 
            SceneManager.LoadScene(loadSceneIdx);
    }
}
