using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayPiano : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject pianoCamera;
    [SerializeField] private ThirdPersonController controller;
    private readonly StarterAssets.StarterAssetsInputs _input;
    private bool _isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        _isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Interaction>() && GetComponent<Interaction>().interactionState && !_isPlaying)
        {
            cameraPiano();
        }
    }

    void cameraPiano()
    {
        mainCamera.SetActive(false);
        controller.enabled = false;
        pianoCamera.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //print("blablabla");
        /*RightHandHandle.grabObj.SetActive(false);
        RightHandHandle.grabObj = null;
        _interactionMenu.SetActive(false);
        controller.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
        controller.gameObject.GetComponent<InteractionController>().canInteract = false;
        GetComponent<Outline>().enabled = false;
        Destroy(GetComponent<Interaction>());
        StartCoroutine(ActiveEnvInteractionCoroutine());*/
    }

}
