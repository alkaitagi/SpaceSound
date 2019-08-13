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

    private void Awake() =>
        GetComponent<InputField>().onValidateInput += delegate (string text, int index, char last)
        {
            return (!letter && char.IsLetter(last)
                    || !digit && char.IsDigit(last)
                    || !symbol && char.IsSymbol(last))
                ? '\0'
                : last;
        };
}