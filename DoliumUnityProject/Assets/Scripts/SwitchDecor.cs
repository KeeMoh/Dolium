using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDecor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public Light light;
    void Start()
    {
        obj.gameObject.SetActive(true);
        light.intensity = 1.0f;
        //red.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.gameObject.SetActive(false);
            light.intensity = 3.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.gameObject.SetActive(true);
            light.intensity = 1.0f;
        }
    }
}
