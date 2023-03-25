using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadLevelMenager : MonoBehaviour {

	private AsyncOperation async = null;

	public int sceneIndex;

	void Start()
	{
        async = SceneManager.LoadSceneAsync(sceneIndex);

        async.allowSceneActivation = false;
    }
    public void PlayScene()
    {
        if (async.isDone)
        {
            async.allowSceneActivation = true;
        }
    }
}
