using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SwitchDecor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> models;
    [SerializeField] private List<Light> lightToTurnOff;
    [SerializeField] private Light lightToIntensify;
    [SerializeField] private GameObject manivelle;
    //[SerializeField] private List<GameObject> colliders;
    //public GameObject obj;
    /*    public Light light;*/
    private Material[] materials;
    private Material dissolveMaterial;
    private Renderer[] renderers;
    
    private Coroutine hide, show;
    List<Material> materialList;
    private float hideDuration = 1.0f;
    private float dissolveAmount = 0f;
    private bool isDissolve = false, isOldingKey = false;
    void Start()
    {
        
        // Récupère le material de chaque objet 3D dans la liste models
        foreach (GameObject model in models)
        {
            renderers = model.GetComponentsInChildren<Renderer>();
            //dissolveMaterial = model.GetComponent<Renderer>().material;
        }

        //materialList = new List<Material>();
        //obj.SetActive(true);
/*        light.intensity = 1.0f;*/
        //renderers = obj.GetComponentsInChildren<Renderer>();
/*        Debug.Log(renderers[0].material);
        Debug.Log(renderers.Length);
        for (int i = 0; i < renderers.Length; i++)
        {
            materialList.Add(renderers[i].material); //Passer par une list.
            Debug.Log(renderers[i].material);
        }
        Debug.Log("Pierre test material :");
*/
        
//        Debug.Log(materials[0]);
        //red.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDissolve = true;
            if (show != null) StopCoroutine(show);
            hide = StartCoroutine(Hide());
            // obj.SetActive(false);
            // light.intensity = 3.0f;
            foreach(Light light in lightToTurnOff)
            {
                light.intensity = 0.5f;
            }
            lightToIntensify.intensity = 80f;
            manivelle.GetComponent<Outline>().enabled= true;
        }
    }
    IEnumerator Show()
    {
        //float startTime = Time.time;
        //float endTime = startTime + hideDuration;
        //float lightPower;

        foreach (Light light in lightToTurnOff)
        {
            light.intensity = 3f;
        }
        lightToIntensify.intensity = 50f;
        while (dissolveAmount > 0f)
            {
                dissolveAmount -= Time.deltaTime * 1f;
                foreach (Renderer renderer in renderers)
                {
                        dissolveMaterial = renderer.material;
                        dissolveMaterial.SetFloat("_Dissolve", dissolveAmount);
                }
                yield return null;
            }
        
     
        /*
        while (Time.time < endTime)
        {
            //float t = (Time.time - startTime) / hideDuration;
            for (int i = 0; i < materialList.Count; i++)
            {
            Color color = materialList[i].color;
            color.a = Mathf.Lerp(1, 0, t);
            materialList[i].color = color;
            }
            light.intensity = Mathf.Lerp(1, 3, t*2);
            
            yield return null;
        }

        gameObject.SetActive(false);
        */
    }

    IEnumerator Hide()
    {
        print("Is not dissolving");
        while (dissolveAmount < 1f)
        {
            dissolveAmount += Time.deltaTime * 0.5f;
            foreach (Renderer renderer in renderers)
            {
                dissolveMaterial = renderer.material;
                dissolveMaterial.SetFloat("_Dissolve", dissolveAmount);
            }
            yield return null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDissolve = false;
            if (hide != null) StopCoroutine(hide);
            show = StartCoroutine(Show());
        }
    }

}
