using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour {
    public FoodType askedFood;
    public void TryToGiveFood() {
        if (!LevelManager.Instance.Player.CarriedItem) return;
        Food carriedFood = LevelManager.Instance.Player.CarriedItem.GetComponent<Food>();
        if (!carriedFood) return;
        if (carriedFood.Type != askedFood) return;

        Destroy(LevelManager.Instance.Player.CarriedItem);
        Debug.Log("Add score");
    }
    public void DisplayObjective() {
        gameObject.SetActive(true);
    }
}
