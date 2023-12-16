using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour, IMovable
{
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MoveToTarget(Vector3 targetPosition, float duration)
    {
        rectTransform.DOAnchorPos(targetPosition, duration).SetEase(Ease.InSine);
    }
}
