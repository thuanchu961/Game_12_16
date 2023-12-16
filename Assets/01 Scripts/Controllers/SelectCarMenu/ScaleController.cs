using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleController : MonoBehaviour, IScale
{
    private RectTransform rectTransform;
    private Vector3 originalScale;
    private bool onScaleCompleted;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }
    public void OnScale(float scaleValue, float duration)
    {
        if (onScaleCompleted)
            return;

        rectTransform.DOScale(scaleValue, duration).SetEase(Ease.InOutSine).OnComplete(() => {
            rectTransform.DOScale(1.3f, 0.1f).SetEase(Ease.OutBounce).OnComplete(() => {
                onScaleCompleted = true;
            });
        });
    }
}
