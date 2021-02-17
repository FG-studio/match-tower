using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    static SceneLoader Instance;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(Instance);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForScreen());
        }
    }

    IEnumerator WaitForScreen()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
