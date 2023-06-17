using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        //float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress >= 1.0f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}