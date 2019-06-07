using System.Collections;

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
            StopAllCoroutines();
            StartCoroutine(Animate());
        }
    }

    [SerializeField, Space(10)]
    private float scale = 1;
    [SerializeField]
    private Vector2 offset;
    [SerializeField]
    private float speed;

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
            transform.localScale = endScale;
            rectTransform.anchoredPosition = endPosition;
            canvasGroup.alpha = 0;
        }
    }

    private void OnValidate() =>
        GetComponent<CanvasGroup>().alpha = IsVisible ? 1 : 0;

    private IEnumerator Animate()
    {
        var targetScale = IsVisible ? startScale : endScale;
        var targetPosition = IsVisible ? startPosition : endPosition;
        var targetAlpha = IsVisible ? 1 : 0;

        while (canvasGroup.alpha != targetAlpha)
        {
            var delta = speed * Time.deltaTime;

            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, delta);
            transform.localScale = Vector2.MoveTowards(transform.localScale, targetScale, delta);
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPosition, delta);

            yield return new WaitForEndOfFrame();
        }
    }

    public void Toggle() => IsVisible = !IsVisible;
}
