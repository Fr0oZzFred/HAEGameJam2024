using UnityEngine;
using TMPro;

public class InputBox : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    [SerializeField] string text1;
    [SerializeField] string text2;
    bool toogle = false;
    private void OnValidate() {
        SetInputText(text1);
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
