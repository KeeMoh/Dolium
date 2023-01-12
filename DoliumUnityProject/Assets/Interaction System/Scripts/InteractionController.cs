using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private Transform interactionMenu; 
    [SerializeField] private Transform interactionSelectionPrefab;
    private List<Transform> interactions = new List<Transform>();
    public List<GameObject> gameObjectsInteractions = new List<GameObject>();
    private int interactionIndex = 0;
    public bool canInteract = true;


    public void CreateInteraction(GameObject gameObjectToInteract)
    {
        Transform newInteraction = Instantiate(interactionSelectionPrefab, Vector3.zero, Quaternion.identity) as Transform;
        
        newInteraction.SetParent(interactionMenu);
        newInteraction.GetChild(0).GetComponent<Text>().text = gameObjectToInteract.GetComponent<Interaction>().interactionName;
        interactions.Add(newInteraction);
        gameObjectsInteractions.Add(gameObjectToInteract);
        if (interactions.Count == 1)
        {
            interactions[0].GetComponent<Image>().color = new Color(0,0.6f,0);
            gameObjectToInteract.GetComponent<Outline>().enabled= true;
        }
        newInteraction.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    public void DeleteInteraction(GameObject gameObjectToInteract)
    {
        foreach (Transform element in interactions)
        {
            if (element.GetChild(0).GetComponent<Text>().text == gameObjectToInteract.GetComponent<Interaction>().interactionName)
            {
                element.gameObject.SetActive(false);
                interactions.Remove(element);
                
                break;
            }
            
        }
        gameObjectsInteractions.Remove(gameObjectToInteract);
        if (interactions.Count >= 1)
        {

            interactions[0].GetComponent<Image>().color = new Color(0, 0.6f, 0);
            gameObjectsInteractions[0].GetComponent<Outline>().enabled = true;
            interactionIndex = 0;

        }
        gameObjectToInteract.GetComponent<Outline>().enabled = false;

    }
    public void ChooseInteraction(float changeIndex)
    {
        if (changeIndex < 0)
        {
            if (interactionIndex < interactions.Count-1)
            {
                
                interactions[interactionIndex].GetComponent<Image>().color = new Color(0.66f, 0, 0);
                gameObjectsInteractions[interactionIndex].GetComponent<Outline>().enabled = false;
                interactionIndex += 1;
                interactions[interactionIndex].GetComponent<Image>().color = new Color(0, 0.6f, 0);
                gameObjectsInteractions[interactionIndex].GetComponent<Outline>().enabled = true;
            }
        }
        
        if (changeIndex > 0)
        {
            if (interactionIndex > 0)
            {
                interactions[interactionIndex].GetComponent<Image>().color = new Color(0.66f, 0, 0);
                gameObjectsInteractions[interactionIndex].GetComponent<Outline>().enabled = false;
                interactionIndex -= 1;
                interactions[interactionIndex].GetComponent<Image>().color = new Color(0, 0.6f, 0);
                gameObjectsInteractions[interactionIndex].GetComponent<Outline>().enabled = true;
            }
        }
    }

    public void ExecuteInteraction()
    {
        if (interactions.Count > 0 && canInteract)
        {
            gameObjectsInteractions[interactionIndex].GetComponent<Interaction>().interactionState = true;
            interactionIndex = 0;
        }
        
    }
}
