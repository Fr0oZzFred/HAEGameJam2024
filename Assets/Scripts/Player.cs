using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10.0f;

    [SerializeField] InputActionAsset inputActions;
    InputAction moveAction;
    Vector3 movement;


    [SerializeField] Transform carriedItemTransform;
    public GameObject CarriedItem => carriedItem;
    GameObject carriedItem;

    SpriteRenderer sr;

    public bool IsVisible => sr.enabled;
    public bool IsCarryingFood => carriedItem.GetComponent<Food>() != null;

    private void Awake() {
        moveAction = inputActions.FindActionMap("Gameplay").FindAction("move");
        sr = GetComponent<SpriteRenderer>();
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
    public void TryToBindFoodDropAction() {
        if (!carriedItem) return;
        Food carriedFood = carriedItem.GetComponent<Food>();
        if (!carriedFood) return;
        carriedFood.BindDropAction();
    }
    public void TryToUnbindFoodDropAction() {
        if (!carriedItem) return;
        Food carriedFood = carriedItem.GetComponent<Food>();
        if (!carriedFood) return;
        carriedFood.UnbindDropAction();
    }

    public void SetCarriedItem(GameObject go) {
        carriedItem = go;
        if (!go) return;
        go.transform.SetParent(carriedItemTransform, false);
        go.transform.localPosition = Vector3.zero;
    }
}
