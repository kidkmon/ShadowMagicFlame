using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    private static string _sceneToLoad;

    public void LoadScene(string sceneName)
    {
        _sceneToLoad = sceneName;
        SceneManager.LoadScene(SceneNames.Loading);
    }

    public static string GetTargetScene() => _sceneToLoad;
}
