using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [Header("Dialogue References")]
    [SerializeField] private DialogueSequenceController dialogueSequenceController;
    private MessageService _service;

    private DialogueData[] _dialogues;
    private Dictionary<string, AvatarData> _avatars;

    async void Start()
    {
        await InitializeService();
        await InitializeAvatars();

        dialogueSequenceController.Initialize(_dialogues, _avatars);
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
