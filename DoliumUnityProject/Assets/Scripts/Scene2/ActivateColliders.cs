using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateColliders : MonoBehaviour
{
    [SerializeField] private List<GameObject> walls;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    public void Desactivation()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void Activation()
    {

        foreach (GameObject wall in walls)
        {
            wall.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

}
