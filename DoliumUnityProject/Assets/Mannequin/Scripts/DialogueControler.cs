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

    private int mannequinDialogueIndex;
    private GameObject NameZoneText;
    private GameObject DialogueZoneText;

    private StarterAssets.StarterAssetsInputs _input;
    
    

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            NameZoneText = mannequinDialoguesUI.transform.Find("NameZone").GetChild(0).gameObject;
            DialogueZoneText = mannequinDialoguesUI.transform.Find("DialoguesZone").GetChild(0).gameObject;
            _input = other.GetComponent<StarterAssets.StarterAssetsInputs>();
            other.GetComponent<InteractionController>().CreateInteraction("New Interaction!");
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_input.interact)
            {
                if (!mannequinDialoguesUI.activeInHierarchy)
                {
                    mannequinDialoguesUI.SetActive(true);
                    StartCoroutine(DisplayDialogue());
                }
                else
                {
                    if(mannequinDialogueIndex < mannequinDialogues.Length)
                    {
                        mannequinDialogueIndex++;

                    }
                    else
                    {
                        mannequinDialogueIndex = 0;
                    }
                    
                    DialogueZoneText.GetComponent<Text>().text = mannequinDialogues[mannequinDialogueIndex];
                }
                _input.interact = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<InteractionController>().DeleteInteraction("New Interaction!");
            NameZoneText.GetComponent<Text>().text = "";
            DialogueZoneText.GetComponent<Text>().text = "";
            mannequinDialoguesUI.GetComponent<Animator>().SetTrigger("Exit");
            StartCoroutine(UndisplayDialogues());
        }
    }

    IEnumerator DisplayDialogue()
    {
        
        yield return new WaitForSeconds(0.35f);
        NameZoneText.GetComponent<Text>().text = mannequinName;
        DialogueZoneText.GetComponent<Text>().text = mannequinDialogues[mannequinDialogueIndex];
        
    }

    IEnumerator UndisplayDialogues()
    {
        yield return new WaitForSeconds(0.7f);
        mannequinDialoguesUI.SetActive(false);
    }
}
