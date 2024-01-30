using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public enum Candy {
    Chocolate = 0,
    Lollipop = 1,
    Candy = 2,
}

public class Food : MonoBehaviour {

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
        LevelManager.Instance.Player.CarriedItem = this.gameObject;
        this.transform.SetParent(LevelManager.Instance.Player.transform);
    }

    void Drop() {
        dropAction.performed -= OnDropAction;
        LevelManager.Instance.Player.CarriedItem = null;
        this.transform.SetParent(null);

    }
    private void OnDropAction(InputAction.CallbackContext ctx) {
        TryToDrop();
    }
}
