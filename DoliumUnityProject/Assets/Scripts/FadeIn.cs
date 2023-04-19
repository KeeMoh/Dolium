using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public Animator FadeInAnimator;
    private int numScene;
    private bool alreadyLoad;
    private void Start()
    {
        alreadyLoad = false;
        numScene = 0;
        PlayerPrefs.SetInt("idscene", 0);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyLoad)
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
                case "Scene4":
                    numScene = 4;
                    break;
                case "Scene5":
                    numScene = 5;
                    break;
            }
            PlayerPrefs.SetInt("idscene", numScene);
            FadeInAnimator.SetBool("fadein", true);
        }
    }
}
