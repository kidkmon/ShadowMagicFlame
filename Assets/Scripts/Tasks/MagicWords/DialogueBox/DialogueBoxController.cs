using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class DialogueBoxController : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float typingSpeed = 0.025f;

    [Header("Message References")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text messageText;
    
    [Header("Avatar References")]
    [SerializeField] private RawImage avatarImage;
    [SerializeField] private Texture2D fallbackAvatar;

    public void Setup(DialogueData dialogueData, AvatarData avatarData, Action onComplete)
    {
        nameText.text = dialogueData.name;
        avatarImage.texture = avatarData.Image ?? fallbackAvatar;
        var message = EmojiHelper.FormatText(dialogueData.text);
        StartCoroutine(TypeMessage(message, onComplete));
    }

    private IEnumerator TypeMessage(string message, Action onComplete)
    {
        messageText.text = string.Empty;
        foreach (char letter in message.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        onComplete?.Invoke();
    }

}