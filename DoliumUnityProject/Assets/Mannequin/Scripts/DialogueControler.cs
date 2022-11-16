using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject mannequinDialoguesUI;
    [SerializeField] private string mannequinName;
    [SerializeField] private string mannequinText;
    


    

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            mannequinDialoguesUI.SetActive(true);
            mannequinDialoguesUI.transform.Find("TextZone").GetChild(0).GetComponent<Text>().text = mannequinText;
            mannequinDialoguesUI.transform.Find("NameZone").GetChild(0).GetComponent<Text>().text = mannequinName;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mannequinDialoguesUI.SetActive(false);
        }
    }
}
