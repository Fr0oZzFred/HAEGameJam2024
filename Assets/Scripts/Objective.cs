using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objective : MonoBehaviour {
    [SerializeField] GameObject bubble;
    [SerializeField] SpriteRenderer askedfoodSprite;
    [SerializeField] List<Sprite> foodIcons;

    Animator animator;

    FoodType askedFood;
    public delegate void OnGiveFoodDelegate(FoodType foodType);
    [SerializeField] UnityEvent OnWrongFood;
    [SerializeField] UnityEvent OnGoodFood;
    public OnGiveFoodDelegate OnGiveFood;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void TryToGiveFood() {
        if (!LevelManager.Instance.Player.CarriedItem) return;
        Food carriedFood = LevelManager.Instance.Player.CarriedItem.GetComponent<Food>();
        if (!carriedFood || carriedFood.Type != askedFood) {
            OnWrongFood.Invoke();
            return;
        }
        OnGoodFood.Invoke();
        OnGiveFood.Invoke(carriedFood.Type);
        Destroy(LevelManager.Instance.Player.CarriedItem);
    }
    public void SetAskedfood(FoodType foodType) {
        askedFood = foodType;
        askedfoodSprite.sprite = foodIcons[(int)foodType];
    }

    public void DisplayObjective(bool b) {
        bubble.SetActive(b);
        animator.SetBool("Open", b);
    }
}
