using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    public void LoadMainMenuScene() => LoadSceneManager.Instance.LoadScene(SceneNames.MainMenu);
}
