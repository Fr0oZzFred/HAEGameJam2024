using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10.0f;

    [SerializeField] InputActionAsset inputActions;
    InputAction moveAction;

    Vector3 movement;
    public GameObject CarriedItem;

    private void Awake() {
        moveAction = inputActions.FindActionMap("Gameplay").FindAction("move");
    }
    void Update() {
        UpdateMovementInput();
    }
    private void FixedUpdate() {
        this.transform.position += movement * speed;
    }
    void UpdateMovementInput() {
        movement = moveAction.ReadValue<Vector2>();
    }
    void OnEnable() {
        inputActions.FindActionMap("gameplay").Enable();
    }
    void OnDisable() {
        inputActions.FindActionMap("gameplay").Disable();
    }
    public void ToggleVisibility() {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        if (GetComponent<SpriteRenderer>().enabled)
            moveAction.Enable();
        else
            moveAction.Disable();
    }
}
