using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum GameStates {
    Menu,
    Credit,
    InGame,
    Pause,
    GameOverLose,
    GameOverWin
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public delegate void OnGameStateChangedDelegate(GameStates newState);
    public OnGameStateChangedDelegate OnGameStateChanged;
    public GameStates CurGameState { get; private set; }
    [SerializeField] GameStates defaultState;

    [SerializeField] InputAction pauseAction;

    public AudioSource MusicSource { get; private set; }
    public bool IsUsingGamepad { get {
            if (Gamepad.current == null) return false;
            return Keyboard.current.lastUpdateTime < Gamepad.current.lastUpdateTime;
        } }

    private void Awake() {
        CurGameState = defaultState;

        if (!Instance)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    IEnumerator Start() {
        MusicSource = GetComponent<AudioSource>();
        pauseAction.performed += OnPauseAsked;
        yield return new WaitForSeconds(0.1f);
        OnGameStateChanged.Invoke(CurGameState);
    }

    private void OnPauseAsked(InputAction.CallbackContext obj) {
        Debug.Log("pause");
    }

    public void ChangeGameState(GameStates newState) {
        CurGameState = newState;
        OnGameStateChanged.Invoke(newState);
    }
    public void ChangeGameState(int newState) {
        ChangeGameState((GameStates)newState);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ChangeGameState(GameStates.Menu);
    }
    public void Quit() {
        Application.Quit();
    }
}