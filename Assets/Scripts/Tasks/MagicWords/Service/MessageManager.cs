using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [Header("Dialogue Box References")]
    [SerializeField] private GameObject dialogueBoxPrefab;
    [SerializeField] private Transform dialogueBoxParent;

    private DialogueBoxFactory _dialogueBoxFactory;
    private MessageService _service;

    private DialogueData[] _dialogues;
    private Dictionary<string, AvatarData> _avatars;

    async void Start()
    {
        _dialogueBoxFactory = new DialogueBoxFactory(dialogueBoxPrefab);
        await InitializeService();
        await InitializeAvatars();

        // TODO: desacoplate this from the service and use a more generic way to get the dialogues
        foreach (var dialogue in _dialogues)
        {
            if (_avatars.TryGetValue(dialogue.name, out var avatarData))
            {
                _dialogueBoxFactory.Create(dialogueBoxParent, dialogue, avatarData);
            }
            else
            {
                Debug.LogWarning($"Avatar not found for dialogue '{dialogue.name}', using fallback.");

                var fallbackAvatar = new AvatarData
                {
                    name = dialogue.name,
                    Image = null,
                    position = "left",
                };

                _dialogueBoxFactory.Create(dialogueBoxParent, dialogue, fallbackAvatar);
                continue;
            }

        }
    }

    async Task InitializeService()
    {
        Debug.Log("Initializing Message Service...");
        _service = new MessageService();
        var response = await _service.FetchMessageResponse();

        response.InitializeAvatars();
        _avatars = response.Avatars;
        _dialogues = response.dialogue;

        Debug.Log("Messages fetched successfully!");

    }

    async Task InitializeAvatars()
    {
        foreach (var avatarData in _avatars.Values)
        {
            var texture = await _service.FetchAvatarImage(avatarData.url);
            if (texture != null)
            {
                avatarData.Image = texture;
            }
        }

    }

}
