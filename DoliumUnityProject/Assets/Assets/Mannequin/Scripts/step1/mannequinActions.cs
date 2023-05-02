using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mannequinActions : MonoBehaviour
{
    static public bool isNotify;
    static public bool loading;
    public int mannequinStepCount;

    public Animator environmentController;

    public AudioSource sourceAudio;

    static public bool desappear;

    // Start is called before the first frame update
    void Start()
    {
        isNotify = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isNotify) {
            loading = true;
            isNotify = false;
            StartCoroutine(nextMannequinAnimator(unactiveMannequin));
        }
    }

    IEnumerator nextMannequinAnimator(Action action)
    {
        environmentController.SetInteger("luminosityStep", mannequinStepCount);
        if (mannequinStepCount <= 2)
        {
            sourceAudio.Play();
        }
        yield return new WaitForSeconds(4);
        action();
    }

    public void unactiveMannequin()
    {
        if (mannequinStepCount <= 2)
        {
            gameObject.SetActive(false);
        }
    }

}
