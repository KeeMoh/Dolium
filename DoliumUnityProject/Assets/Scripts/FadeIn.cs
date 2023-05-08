using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public Animator FadeInAnimator;
    private int numScene;
    private bool alreadyLoad;
    public bool load;
    private void Start()
    {
        load = false;
        alreadyLoad = false;
        numScene = 0;
        PlayerPrefs.SetInt("idscene", 0);
    }

    private void Update()
    {
        if (load)
        {
            if (!alreadyLoad)
            {
                alreadyLoad = true;
                FadeInSettings();
            }
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyLoad)
        {
            alreadyLoad = true;
            FadeInSettings();
        }
    }

    private void FadeInSettings()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Scene1":
                numScene = 1;
                break;
            case "Scene2":
                numScene = 2;
                break;
            case "Scene3":
                numScene = 3;
                break;
        }
        PlayerPrefs.SetInt("idscene", numScene);
        FadeInAnimator.SetBool("fadein", true);
    }
}
