using UnityEngine;
using TMPro;

public class InputBox : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    [SerializeField] string text1;
    [SerializeField] string text2;
    bool toogle = false;
    [SerializeField] SpriteRenderer input;
    [SerializeField] Sprite inputPC;
    [SerializeField] Sprite inputGamepad;

    private void OnValidate() {
        SetInputText(text1);
    }
    private void Update() {
        input.sprite = GameManager.Instance.IsUsingGamepad ? inputGamepad : inputPC;
    }
    public void ToogleText() {
        toogle = !toogle;
        if (toogle) SetInputText(text2);
        else SetInputText(text1);
    }
    public void SetInputText(string inputText) {
        text.SetText(inputText);
    }
}
