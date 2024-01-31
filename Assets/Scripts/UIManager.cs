using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] Slider NoiseGauge;

    [SerializeField] GameObject mainMenuHUD;
    [SerializeField] GameObject creditsHUD;
    [SerializeField] GameObject inGameHUD;
    [SerializeField] GameObject pauseHUD;
    [SerializeField] GameObject gameOverBadHUD;
    [SerializeField] GameObject gameOverGoodHUD;

    private void Awake() {
        if (!Instance)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start() {
        LevelManager.Instance.OnNoiseChanged += OnNoiseChanged;
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnNoiseChanged(float NewNoise) {
        NoiseGauge.value = LevelManager.Instance.Noise * 0.01f;
    }

    private void OnGameStateChanged(GameStates newState) {
        mainMenuHUD     .SetActive(newState == GameStates.Menu);
        creditsHUD      .SetActive(newState == GameStates.Credit);
        inGameHUD       .SetActive(newState == GameStates.InGame);
        pauseHUD        .SetActive(newState == GameStates.Pause);
        gameOverBadHUD  .SetActive(newState == GameStates.GameOverLose);
        gameOverGoodHUD .SetActive(newState == GameStates.GameOverWin);
    }
}
