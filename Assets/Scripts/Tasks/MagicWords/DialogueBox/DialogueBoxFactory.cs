using UnityEngine;

public class DialogueBoxFactory
{
    private readonly GameObject _dialoguePrefab;

    public DialogueBoxFactory(GameObject dialoguePrefab)
    {
        _dialoguePrefab = dialoguePrefab;
    }

    public GameObject Create(Transform parent, DialogueData data, AvatarData avatarData)
    {
        GameObject go = Object.Instantiate(_dialoguePrefab, parent);
        var controller = go.GetComponent<DialogueBoxController>();
        controller.SetData(data, avatarData);
        return go;
    }
}