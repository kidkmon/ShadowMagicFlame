using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MessageResponse
{
    public DialogueData[] dialogue;
    public AvatarData[] avatars;

    public Dictionary<string, AvatarData> Avatars;

    public void InitializeAvatars()
    {
        Avatars = new Dictionary<string, AvatarData>();
        foreach (var avatar in avatars)
        {
            Avatars[avatar.name] = avatar;
        }
    }
}
