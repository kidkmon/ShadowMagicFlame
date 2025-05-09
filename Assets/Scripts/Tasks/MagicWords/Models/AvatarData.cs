using System;
using UnityEngine;

public enum AvatarPostion
{
    Left,
    Right
}

[Serializable]
public class AvatarData
{
    public string name;
    public string url;
    public string position;
    public Texture2D Image;
    
    public AvatarPostion GetAvatarPostion()
    {
        if (Enum.TryParse(position, true, out AvatarPostion avatarPosition))
        {
            position = avatarPosition switch
            {
                AvatarPostion.Left => "left",
                AvatarPostion.Right => "right",
                _ => "left",
            };
            return avatarPosition;
        }
        return AvatarPostion.Left;
    }
}