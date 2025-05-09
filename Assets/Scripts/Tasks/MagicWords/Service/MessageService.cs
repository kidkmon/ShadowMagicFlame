using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class MessageService
{
    private const string API_URL = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

    public async Task<MessageResponse> FetchMessageResponse()
    {
        UnityWebRequest request = UnityWebRequest.Get(API_URL);
        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning($"Failed to fetch messages: {request.error}");
            return new MessageResponse();
        }

        var json = request.downloadHandler.text;
        MessageResponse data = JsonUtility.FromJson<MessageResponse>(json);
        return data;
    }

    public async Task<Texture2D> FetchAvatarImage(string url, bool isRetry = false)
    {
        if (string.IsNullOrEmpty(url))
            return null;

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogWarning($"Failed to fetch avatar image: {request.error}");

            if (isRetry) return null;

            var fixedUrl = TryFixAvatarUrl(url);
            Debug.LogWarning($"Tring to fetch avatar again with fixed URL: {url}");
            return await FetchAvatarImage(fixedUrl, true);
        }

        return DownloadHandlerTexture.GetContent(request);
    }

    // Method to fix possible URL issues
    private string TryFixAvatarUrl(string url)
    {
        if (url.EndsWith("personas/"))
        {
            url += "png";
        }

        return url;
    }

}