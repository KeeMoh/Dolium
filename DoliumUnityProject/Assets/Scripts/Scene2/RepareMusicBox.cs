using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class RepareMusicBox : MonoBehaviour
{
    [SerializeField] private GameObject animatorRef;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera musicBoxCamera;
    [SerializeField] private ThirdPersonController controller;
    [SerializeField] private GameObject piano;
    public AudioSource sourceAudio;
    private GameObject _interactionMenu;
    private void Start()
    {
        _interactionMenu = GameObject.Find("InteractionMenu");
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Interaction>() && GetComponent<Interaction>().interactionState)
        {
            if (RightHandHandle.grabObj != null && RightHandHandle.grabObj.CompareTag("Key"))
            {
                mainCamera.enabled = false;
                controller.enabled= false;
                musicBoxCamera.enabled = true;
                RightHandHandle.grabObj.SetActive(false);
                RightHandHandle.grabObj = null;
                _interactionMenu.SetActive(false);
                controller.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
                controller.gameObject.GetComponent<InteractionController>().canInteract = false;
                GetComponent<Outline>().enabled = false;
                Destroy(GetComponent<Interaction>());
                StartCoroutine(ActiveEnvInteractionCoroutine());
                
            }
            else
            {
                GetComponent<Interaction>().interactionState = false;
            }
        }
    }

    IEnumerator ActiveEnvInteractionCoroutine()
    {
        animatorRef.GetComponent<Animator>().SetTrigger("Repare");
        
        yield return new WaitForSeconds(3.5f);
        sourceAudio.Play();
        yield return new WaitForSeconds(4.5f);
        musicBoxCamera.enabled = false; 
        //controller.transform.position = position;
        controller.enabled = true;
        mainCamera.enabled = true;
        piano.AddComponent<Interaction>();
        piano.AddComponent<Outline>();
        piano.GetComponent<Outline>().enabled = false;
        piano.GetComponent<Interaction>().interactionName= "Use Piano";
        //GetComponent<ActivateColliders>().Desactivation();
        _interactionMenu.SetActive(true);
        controller.gameObject.GetComponent<InteractionController>().canInteract = true;
        //GameObject.Find("InteractionMenu").SetActive(true);
    }
}
