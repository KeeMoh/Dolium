using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAnimStartScene : MonoBehaviour
{
    public int sceneNb;
    public Animator camAnimator;

    private void Start()
    {
        GetComponent<Animator>().SetInteger("sceneNb", sceneNb);
        camAnimator.SetInteger("sceneNb", sceneNb);
    }
}
