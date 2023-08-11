using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private const string StartScene = "GameScene";

    public AsyncOperation LoadStartScene()
    {
        var asyncOperation = SceneManager.LoadSceneAsync(StartScene);
        
        return asyncOperation;
    }
}