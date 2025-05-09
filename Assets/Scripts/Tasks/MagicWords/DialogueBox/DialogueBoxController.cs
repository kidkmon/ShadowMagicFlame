using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{
    [Header("Message References")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text messageText;
    
    [Header("Avatar References")]
    [SerializeField] private RawImage avatarImage;
    [SerializeField] private Texture2D fallbackAvatar;

    public void SetData(DialogueData dialogueData, AvatarData avatarData)
    {
        nameText.text = dialogueData.name;
        messageText.text = dialogueData.text;
        avatarImage.texture = avatarData.Image ?? fallbackAvatar;
    }

}