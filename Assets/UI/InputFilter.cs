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

    private bool IsDigit(char c, int i) =>
        !digit || char.IsDigit(c) && (c != '0' || i > 0);

    private bool isSymbol(char c) =>
       !symbol || char.IsSymbol(c);

    private void Awake() =>
        GetComponent<InputField>().onValidateInput +=
            (string text, int index, char last) =>
                IsLetter(last) && IsDigit(last, index) && isSymbol(last)
                    ? last : '\0';
}
