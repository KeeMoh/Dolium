using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update

    public bool interactionState;
    public string interactionName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("GrableObj"))
            {
                if (RightHandHandle.grabObj == null)
                {
                    other.GetComponent<InteractionController>().CreateInteraction(gameObject);
                }
                else
                {
                    if (gameObject != RightHandHandle.grabObj)
                    {
                        other.GetComponent<InteractionController>().CreateInteraction(gameObject);
                    }
                }
            }
            else if (gameObject.CompareTag("ActionEnv"))
            {
                other.GetComponent<InteractionController>().CreateInteraction(gameObject);
            }
            else
            {
                other.GetComponent<InteractionController>().CreateInteraction(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<InteractionController>().DeleteInteraction(gameObject);
        }

    }
}