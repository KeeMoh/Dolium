using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInteraction : MonoBehaviour
{
    private Interaction _interaction;

    static bool actionLoading;
    private bool isOpen;

    private void Start()
    {
        actionLoading = false;
        isOpen = GetComponent<Animator>().GetBool("open");
        GetComponent<Interaction>().interactionName = isOpen ? "Fermer" : "Ouvrir";
        _interaction = GetComponent<Interaction>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!actionLoading)
            {
                if (_interaction.interactionState)
                {
                    ActiveEnvInteraction(other);
                    actionLoading = true;
                }
            }
        }
    }

    void ActiveEnvInteraction(Collider other)
    {
        _interaction.interactionState = false;
        other.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
        other.gameObject.GetComponent<InteractionController>().canInteract = false;
        StartCoroutine(ActiveEnvInteractionCoroutine(other));
    }

    IEnumerator ActiveEnvInteractionCoroutine(Collider other)
    {
        isOpen = GetComponent<Animator>().GetBool("open");
        GetComponent<Animator>().SetBool("open", !isOpen);
        GetComponent<Interaction>().interactionName = !isOpen ? "Fermer" : "Ouvrir";
        other.gameObject.GetComponent<InteractionController>().CreateInteraction(gameObject);
        other.gameObject.GetComponent<InteractionController>().canInteract = true;
        yield return new WaitForSeconds(2);
        actionLoading = false;
    }
}
