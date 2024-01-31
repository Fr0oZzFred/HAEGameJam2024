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
    Animator animator;

    public bool IsVisible => sr.enabled;
    public bool IsCarryingFood => carriedItem.GetComponent<Food>() != null;

    private void Awake() {
        moveAction = inputActions.FindActionMap("Gameplay").FindAction("move");
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Start() {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        OnDisable();
    }
    private void OnGameStateChanged(GameStates newState) {
        if (newState == GameStates.InGame) OnEnable();
        else OnDisable();
    }

    void Update() {
        UpdateMovementInput();
    }
    private void FixedUpdate() {
        this.transform.position += movement * speed;
    }
    void UpdateMovementInput() {
        movement = moveAction.ReadValue<Vector2>();
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);
        animator.SetBool("IsMoving", movement.magnitude != 0.0f);
    }
    void OnEnable() {
        inputActions.FindActionMap("gameplay").Enable();
    }
    void OnDisable() {
        inputActions.FindActionMap("gameplay").Disable();
    }
    public void ToggleVisibility() {
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        if (carriedItem) carriedItem.SetActive(!carriedItem.activeInHierarchy);
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
