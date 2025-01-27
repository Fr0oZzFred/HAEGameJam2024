using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum FoodType {
    Candy = 0,
    CandyCorn = 1,
    Chocolate = 2,
    LollipopA = 3,
    LollipopB = 4,
}

public class Food : MonoBehaviour {
    public FoodType Type => type;
    [SerializeField] FoodType type;


    [SerializeField] InputActionAsset inputActions;
    InputAction dropAction;

    private void Awake() {
        dropAction = inputActions.FindActionMap("gameplay").FindAction("interact");
    }

    public void TryToPickup() {
        if (!LevelManager.Instance.Player.CarriedItem)
            Pickup();
    }
    public void TryToDrop() {
        if (LevelManager.Instance.Player.CarriedItem == this.gameObject)
            Drop();
    }
    void Pickup() {
        dropAction.performed += OnDropAction;
        LevelManager.Instance.Player.SetCarriedItem(this.gameObject);
    }

    void Drop() {
        dropAction.performed -= OnDropAction;
        LevelManager.Instance.Player.SetCarriedItem(null);
        this.transform.SetParent(null);

    }
    private void OnDropAction(InputAction.CallbackContext ctx) {
        TryToDrop();
    }
    public void BindDropAction() {
        dropAction.performed += OnDropAction;
    }
    public void UnbindDropAction() {
        dropAction.performed -= OnDropAction;
    }

    private void OnDestroy() {
        UnbindDropAction();
    }
}
