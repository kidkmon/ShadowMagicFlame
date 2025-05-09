using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSequenceController : MonoBehaviour
{
    [Header("Dialogue Box References")]
    [SerializeField] private GameObject dialogueBoxPrefab;
    [SerializeField] private Transform dialogueBoxParent;

    [Header("Dialogue Settings")]
    [SerializeField] private float autoAdvanceTime = 0.5f;
    [SerializeField] private int maxVisibleDialogues = 3;
    [SerializeField] private float dialogueOffsetY = 120f;
    [SerializeField] private Button nextButton;

    private DialogueBoxFactory _dialogueBoxFactory;
    private DialogueData[] _dialogues;
    private Dictionary<string, AvatarData> _avatars;

    private int _currentIndex = 0;
    private Coroutine _autoAdvanceCoroutine;
    private Queue<RectTransform> _activeMessages = new();

    public void Initialize(DialogueData[] dialogueData, Dictionary<string, AvatarData> avatars)
    {
        _dialogues = dialogueData;
        _avatars = avatars;

        _dialogueBoxFactory = new DialogueBoxFactory(dialogueBoxPrefab);

        nextButton.onClick.AddListener(AdvanceManually);

        ShowCurrent();
    }

     private void ShowCurrent()
    {
        if (_currentIndex >= _dialogues.Length)
        {
            Debug.Log("End of dialogue.");
            return;
        }

        var dialogueData = _dialogues[_currentIndex];
        var avatarData = GetAvatarData(dialogueData.name);
        var dialog = _dialogueBoxFactory.CreateDialog(dialogueBoxParent, dialogueData, avatarData, () =>
        {
            _autoAdvanceCoroutine = StartCoroutine(AutoAdvanceCoroutine());
        });

        RectTransform msgTransform = dialog.GetComponent<RectTransform>();
        msgTransform.anchoredPosition = new Vector2(0, -dialogueOffsetY);

        AnimateExistingMessagesUp();
        AnimateNewMessageIn(msgTransform);

        _activeMessages.Enqueue(msgTransform);

        if (_activeMessages.Count > maxVisibleDialogues)
        {
            var old = _activeMessages.Dequeue();
            Destroy(old.gameObject);
        }
    }

    private void AnimateExistingMessagesUp()
    {
        foreach (var msg in _activeMessages)
        {
            if (msg != null)
                msg.DOAnchorPosY(msg.anchoredPosition.y + dialogueOffsetY, 0.3f).SetEase(Ease.OutCubic);
        }
    }

    private void AnimateNewMessageIn(RectTransform msg)
    {
        msg.DOAnchorPosY(0, 0.3f).SetEase(Ease.OutBack);
    }

    private void AdvanceManually()
    {
        if (_autoAdvanceCoroutine != null)
            StopCoroutine(_autoAdvanceCoroutine);

        _currentIndex++;
        ShowCurrent();
    }

    private IEnumerator AutoAdvanceCoroutine()
    {
        yield return new WaitForSeconds(autoAdvanceTime);
        AdvanceManually();
    }

    private AvatarData GetAvatarData(string name)
    {
        if (_avatars.TryGetValue(name, out var avatarData))
        {
            return avatarData;
        }
        else
        {
            Debug.LogWarning($"Avatar not found for dialogue '{name}', using fallback.");

            return new AvatarData
            {
                name = name,
                Image = null,
                position = "left",
            };
        }
    }
}
