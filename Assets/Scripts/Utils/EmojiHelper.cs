
using System.Text.RegularExpressions;

public static class EmojiHelper
{
    public static string FormatText(string text)
    {
        return Regex.Replace(text, @"\{(.*?)\}", match =>
        {
            string emojiName = match.Groups[1].Value;
            return ParseEmoji(emojiName);
        });
    }


    public static string ParseEmoji(string emojiName)
    {
        return emojiName switch
        {
            "satisfied" => "😌",
            "intrigued" => "🤔",
            "neutral" => "😐",
            "affirmative" => "👍",
            "laughing" => "😂",
            "win" => "🏆",
            _ => emojiName,
        };
    }
}