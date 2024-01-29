using System;
using System.Collections;
using System.Collections.Generic;
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
        interactAction.performed += ctx => { OnInteract(ctx); };
        interactAction.Disable();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerEnter(collision.gameObject.GetComponent<Player>());
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerLeave(collision.gameObject.GetComponent<Player>());

    }
    private void OnPlayerEnter(Player player) {
        interactAction.Enable();
    }
    private void OnPlayerLeave(Player player) {
        interactAction.Disable();
    }

    void OnInteract(InputAction.CallbackContext context) {
        onInteractEvent.Invoke();
    }
}
