using System;
using UnityEngine;

public class DialogueBoxFactory
{
    private readonly GameObject _dialoguePrefab;

    public DialogueBoxFactory(GameObject dialoguePrefab)
    {
        _dialoguePrefab = dialoguePrefab;
    }

    public GameObject CreateDialog(Transform parent, DialogueData data, AvatarData avatarData, Action onComplete)
    {
        GameObject go = UnityEngine.Object.Instantiate(_dialoguePrefab, parent);
        var controller = go.GetComponent<DialogueBoxController>();
        controller.Setup(data, avatarData, onComplete);
        return go;
    }
}