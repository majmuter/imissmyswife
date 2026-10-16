using UnityEngine;

public class FadeText : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeSpeed = 5f;
    private float targetAlpha = 0f;

    void Start()
    {
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
    }

    public void FadeIn()
    {
        targetAlpha = 1f;
    }

    public void FadeOut()
    {
        targetAlpha = 0f;
    }
}


