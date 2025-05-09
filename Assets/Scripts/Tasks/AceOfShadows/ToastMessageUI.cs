using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ToastMessageUI : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private RectTransform toastTransform;
    [SerializeField] private float travelDuration = 0.5f;
    [SerializeField] private float returnDuration = 0.6f;
    [SerializeField] private float delay = 0.3f;

    [Header("Fade")]
    [SerializeField] private float fadeInTime = 0.3f;
    [SerializeField] private float fadeOutTime = 0.6f;

    private CanvasGroup _canvasGroup;
    private Vector3 _leftOffscreen;
    private Vector3 _rightOffscreen;
    private Vector3 _center;

    public static ToastMessageUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _canvasGroup = GetComponent<CanvasGroup>();
        _center = toastTransform.anchoredPosition;

        float canvasWidth = ((RectTransform)toastTransform.parent).rect.width;
        float offsetX = canvasWidth * 0.6f;

        _leftOffscreen = _center + Vector3.left * offsetX;
        _rightOffscreen = _center + Vector3.right * offsetX;

        gameObject.SetActive(false);
    }

    public void ShowMessage(string message, Action onComplete = null)
    {
        messageText.text = message;
        toastTransform.anchoredPosition = _leftOffscreen;
        gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_canvasGroup.DOFade(1f, fadeInTime));
        seq.Append(toastTransform.DOAnchorPos(_rightOffscreen, travelDuration).SetEase(Ease.InSine));
        seq.Append(toastTransform.DOAnchorPos(_center, returnDuration).SetEase(Ease.OutBack));
        seq.Join(toastTransform.DOScale(1.3f, returnDuration).SetEase(Ease.OutExpo));
        seq.AppendCallback(() => { }); // TODO audio
        seq.AppendInterval(delay);
        seq.Join(_canvasGroup.DOFade(0f, fadeOutTime));
        seq.AppendInterval(delay);
        seq.OnComplete(() => 
        {
            gameObject.SetActive(false);
            onComplete?.Invoke();
        });
    }
}
