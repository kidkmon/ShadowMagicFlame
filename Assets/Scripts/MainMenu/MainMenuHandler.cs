using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public void LoadAceOfShadowsScene() => LoadSceneManager.Instance.LoadScene(SceneNames.AceOfShadows);
    public void LoadMagicWordsScene() => LoadSceneManager.Instance.LoadScene(SceneNames.MagicWords);
    public void LoadPhoenixFlameScene() => LoadSceneManager.Instance.LoadScene(SceneNames.PhoenixFlame);
    public void QuitGame() => Application.Quit();
}
