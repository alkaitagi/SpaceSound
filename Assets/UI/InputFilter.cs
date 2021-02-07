using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFilter : MonoBehaviour
{
    [SerializeField]
    private bool letter;
    [SerializeField]
    private bool digit;
    [SerializeField]
    private bool symbol;

    private bool IsLetter(char c) =>
        !letter || (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z');

    private bool IsDigit(char c) =>
        !digit || char.IsDigit(c);

    private bool isSymbol(char c) =>
       !symbol || char.IsSymbol(c);

    private void Awake() =>
        GetComponent<InputField>().onValidateInput +=
            (string text, int index, char last) =>
                IsLetter(last) && IsDigit(last) && isSymbol(last)
                    ? last : '\0';
}
