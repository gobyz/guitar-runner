
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation async = null;

    public int sceneIndex;
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());  
    }
    public void PlayScene()
    {
        async.allowSceneActivation = true;
    }
    public IEnumerator LoadYourAsyncScene()
    {
        async = SceneManager.LoadSceneAsync(sceneIndex);

        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            yield return null;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
