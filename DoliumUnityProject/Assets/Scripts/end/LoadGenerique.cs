using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGenerique : MonoBehaviour
{
    private bool loading;
    public bool load;
    private void Start()
    {
        load = false;
        loading = false;
    }

    private void Update()
    {
        if (load)
        {
            if (!loading)
            {
                loading = true;
                ChangeScene.sceneName = "Generique_final";
            }
        }
    }
}
