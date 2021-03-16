using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    public static SceneLoader Instance;

    private void Awake() {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadEndScene()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
