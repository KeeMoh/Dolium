using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Transform interactionMenu; 
    [SerializeField] private Transform interactionSelectionPrefab;
    private List<Transform> interactions = new List<Transform>();


    public void CreateInteraction(string interactionText)
    {
        Transform newInteraction = Instantiate(interactionSelectionPrefab, Vector3.zero, Quaternion.identity) as Transform;

        newInteraction.SetParent(interactionMenu);
        newInteraction.GetChild(0).GetComponent<Text>().text = interactionText;
        interactions.Add(newInteraction);
    }

    public void DeleteInteraction(string interactionText)
    {
        foreach (Transform element in interactions)
        {
            if (element.GetChild(0).GetComponent<Text>().text == interactionText)
            {
                element.gameObject.SetActive(false);
                interactions.Remove(element);
                break;
            }
        }
    }
}
