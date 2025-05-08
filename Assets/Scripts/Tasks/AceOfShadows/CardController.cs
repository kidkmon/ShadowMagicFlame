using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetCardSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;

    public void SetSortingOrder(int order) => _spriteRenderer.sortingOrder = order;

    public void MoveTo(Vector3 targetPosition, float duration, Action onComplete = null)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.2f, duration * 0.25f).SetEase(Ease.OutBack));
        seq.Append(transform.DOMove(targetPosition, duration).SetEase(Ease.InOutSine));
        seq.Append(transform.DOScale(1f, duration * 0.25f).SetEase(Ease.InBack));
        seq.OnComplete(() => onComplete?.Invoke());
    }
}
