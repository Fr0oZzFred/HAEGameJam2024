using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {
    [SerializeField] List<Sprite> foodIcons;
    [SerializeField] SpriteRenderer askedfoodSprite;

    Animator animator;

    FoodType askedFood;
    public delegate void OnGiveFoodDelegate(FoodType foodType);
    public OnGiveFoodDelegate OnGiveFood;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void TryToGiveFood() {
        if (!LevelManager.Instance.Player.CarriedItem) return;
        Food carriedFood = LevelManager.Instance.Player.CarriedItem.GetComponent<Food>();
        if (!carriedFood) return;
        if (carriedFood.Type != askedFood) return;

        OnGiveFood.Invoke(carriedFood.Type);
        Destroy(LevelManager.Instance.Player.CarriedItem);
    }

    public void SetAskedfood(FoodType foodType) {
        askedFood = foodType;
        askedfoodSprite.sprite = foodIcons[(int)foodType];
    }

    public void DisplayObjective(bool b) {
        animator.SetBool("Open", b);
    }
}
