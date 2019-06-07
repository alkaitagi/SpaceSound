using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class CanvasToggle : MonoBehaviour
{
    [SerializeField]
    private bool isVisible;
    public bool IsVisible
    {
        get => isVisible;
        set
        {
            isVisible = value;
            canvasGroup.blocksRaycasts = IsVisible;
            enabled = true;
        }
    }

    [SerializeField, Space(10)]
    private float scale = 1;
    [SerializeField]
    private Vector2 offset;

    [SerializeField, Space(10)]
    private float duration = .15f;
    private float timer = 0;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private Vector2 startScale;
    private Vector2 endScale;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();

        startPosition = rectTransform.anchoredPosition;
        endPosition = startPosition + offset;

        startScale = transform.localScale;
        endScale = scale * startScale;

        if (!IsVisible)
        {
            canvasGroup.blocksRaycasts = false;
            timer = 1;
            Assign();
        }
    }

    private void OnValidate() =>
        GetComponent<CanvasGroup>().alpha = IsVisible ? 1 : 0;

    private void Update()
    {
        var timer = Mathf.Clamp01(this.timer + (IsVisible ? -1 : 1) * Time.unscaledDeltaTime / duration);
        if (timer != this.timer)
        {
            this.timer = timer;
            Assign();
        }
        else
            enabled = false;
    }

    private void Assign()
    {
        canvasGroup.alpha = Mathf.Lerp(1, 0, timer);
        transform.localScale = Vector2.Lerp(startScale, endScale, timer);
        rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, timer);
    }

    public void Toggle() => IsVisible = !IsVisible;
}
