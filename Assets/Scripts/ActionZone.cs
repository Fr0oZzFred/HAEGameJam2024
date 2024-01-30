using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class ActionZone : MonoBehaviour {
    [SerializeField] InputActionAsset inputActions;
    InputAction interactAction;

    [SerializeField] UnityEvent onInteractEvent;
    private void Awake() {
        interactAction = inputActions.FindActionMap("gameplay").FindAction("interact");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerEnter();
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerLeave();

    }
    private void OnPlayerEnter() {
        interactAction.performed += OnInteract;
    }
    private void OnPlayerLeave() {
        interactAction.performed -= OnInteract;
    }

    void OnInteract(InputAction.CallbackContext context) {
        onInteractEvent.Invoke();
    }
}
