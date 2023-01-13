using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject mannequinDialoguesUI;
    [SerializeField] private string mannequinName;
    [SerializeField] private string[] mannequinDialogues;
    [SerializeField] private string interactionName;

    private bool dialoguesDisplayed;

    private int mannequinDialogueIndex;
    private GameObject NameZoneText;
    private GameObject DialogueZoneText;

    private StarterAssets.StarterAssetsInputs _input;
    private Interaction _interaction;
    private GameObject _interactionMenu;


    private void Start()
    {
        _interaction = GetComponent<Interaction>();
        _interactionMenu = GameObject.Find("InteractionMenu");
    }




    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!dialoguesDisplayed)
            {
                if (_interaction.interactionState)
                {
                    DisplayDialogues(other);
                    dialoguesDisplayed = true;
                }
            }
            else if (_input.interact && dialoguesDisplayed)
            {

                ChangeDialogues(other);
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UndisplayDialogues(other);
        }
    }


    private void DisplayDialogues(Collider other)
    {
        NameZoneText = mannequinDialoguesUI.transform.Find("NameZone").GetChild(0).gameObject;
        DialogueZoneText = mannequinDialoguesUI.transform.Find("DialoguesZone").GetChild(0).gameObject;
        mannequinDialoguesUI.SetActive(true);
        StartCoroutine(DisplayDialogueCoroutine());
        _input = other.GetComponent<StarterAssets.StarterAssetsInputs>();
        _interaction.interactionState = false;
        _interactionMenu.SetActive(false);
        other.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
        other.gameObject.GetComponent<InteractionController>().canInteract = false;
        
        
    }

    private void ChangeDialogues(Collider other)
    {
        if (mannequinDialogueIndex < mannequinDialogues.Length )
        {
            mannequinDialogueIndex++;
        }
        else
        {
            mannequinDialogueIndex = 0;
            UndisplayDialogues(other);
            other.GetComponent<InteractionController>().CreateInteraction(gameObject);
        }

        if (mannequinDialogueIndex <= mannequinDialogues.Length && mannequinDialogueIndex > 0)
        {
            DialogueZoneText.GetComponent<Text>().text = mannequinDialogues[mannequinDialogueIndex-1];
        }
        
        _input.interact = false;
    }

    private void UndisplayDialogues(Collider other)
    {
        if (mannequinDialoguesUI.activeInHierarchy)
        {
            other.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
            NameZoneText.GetComponent<Text>().text = "";
            DialogueZoneText.GetComponent<Text>().text = "";
            mannequinDialoguesUI.GetComponent<Animator>().SetTrigger("Exit");
            StartCoroutine(UndisplayDialoguesCoroutine());
        }
     
        other.GetComponent<InteractionController>().canInteract = true;
        _interactionMenu.SetActive(true);
    }

    IEnumerator DisplayDialogueCoroutine()
    {
        
        yield return new WaitForSeconds(0.35f);
        NameZoneText.GetComponent<Text>().text = mannequinName;
        DialogueZoneText.GetComponent<Text>().text = mannequinDialogues[0];
        
    }

    IEnumerator UndisplayDialoguesCoroutine()
    {
        
        yield return new WaitForSeconds(0.7f);
        mannequinDialoguesUI.SetActive(false);
        dialoguesDisplayed = false;
    }
}
