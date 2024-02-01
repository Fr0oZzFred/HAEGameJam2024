using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] Slider NoiseGauge;

    [SerializeField] GameObject mainMenuHUD;
    [SerializeField] GameObject creditsHUD;
    [SerializeField] GameObject inGameHUD;
    [SerializeField] GameObject pauseHUD;
    [SerializeField] GameObject gameOverBadHUD;
    [SerializeField] GameObject gameOverGoodHUD;

    [Header("First Selected")]
    [SerializeField] GameObject mainMenuFirstSelected;
    [SerializeField] GameObject creditsFirstSelected;
    [SerializeField] GameObject inGameFirstSelected;
    [SerializeField] GameObject pauseFirstSelected;
    [SerializeField] GameObject gameOverLoseFirstSelected;
    [SerializeField] GameObject gameOverWinFirstSelected;


    [SerializeField] EventSystem eventSystem;
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
        switch (newState) {
            case GameStates.Menu:
                SetFocus(mainMenuFirstSelected);
                break;
            case GameStates.Credit:
                SetFocus(creditsFirstSelected);
                break;
            case GameStates.InGame:
                SetFocus(inGameFirstSelected);
                break;
            case GameStates.Pause:
                SetFocus(pauseFirstSelected);
                break;
            case GameStates.GameOverLose:
                SetFocus(gameOverLoseFirstSelected);
                break;
            case GameStates.GameOverWin:
                SetFocus(gameOverWinFirstSelected);
                break;
            default:
                break;
        }
    }
    void SetFocus(GameObject newFocus) {
        if(newFocus)
            eventSystem.SetSelectedGameObject(newFocus);
    }
}
