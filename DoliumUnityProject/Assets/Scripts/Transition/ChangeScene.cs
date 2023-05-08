using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public bool sceneEnding;
    public static string sceneName;
    private bool load;
    void Start()
    {
        sceneName = "Transition";
        sceneEnding = false;
        load = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneEnding)
        {
            if (!load)
            {
                load = true;
                if (SceneManager.GetActiveScene().name == "Scene3")
                {
                    sceneName = "LastTransition";
                    SceneManager.LoadScene(sceneName);
                } else
                {
                    SceneManager.LoadScene(sceneName);
                }
                
            }
        }
    }
}
