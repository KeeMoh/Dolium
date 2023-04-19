using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToTransition : MonoBehaviour
{
    public bool sceneEnding;
    private bool load;
    void Start()
    {
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
                SceneManager.LoadScene("Transition");
            }
        }
    }
}
