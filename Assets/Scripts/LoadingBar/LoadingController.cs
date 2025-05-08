using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [Header("Loading Scene Settings")]
    [SerializeField] private float minLoadingTime = 2f;

    [Header("Loading UI Elements")]
    [SerializeField] private TMP_Text loadingText;
    [SerializeField] private Slider loadingBar;

    private float _currentProgress = 0f;

    void Start()
    {
        string nextScene = LoadSceneManager.GetTargetScene();
        StartCoroutine(LoadSceneAsync(nextScene));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float timer = 0f;

        while (timer < minLoadingTime)
        {
            timer += Time.deltaTime;
            _currentProgress = Mathf.Lerp(0f, 0.9f, timer / minLoadingTime);
            UpdateUI(_currentProgress);
            yield return null;
        }

        while (op.progress < 0.9f)
        {
            UpdateUI(op.progress);
            yield return null;
        }

        timer = 0f;

        while (loadingBar.value < 1f)
        {
            timer += Time.deltaTime;
            _currentProgress = Mathf.Lerp(loadingBar.value, 1f, timer / 1f);
            UpdateUI(_currentProgress);
        }

        op.allowSceneActivation = true;
    }

    private void UpdateUI(float progress)
    {
        loadingBar.value = progress;
        loadingText.text = $"{Mathf.RoundToInt(progress * 100)}%";
    }
}
