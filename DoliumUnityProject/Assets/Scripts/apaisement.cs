using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apaisement : MonoBehaviour
{

    private Material _materialOne;
    private Material _materialTwo;

    public void InitializeSkyboxChanger()
    {
        _materialOne = Resources.Load<Material>("Materials/M1");
        _materialTwo = Resources.Load<Material>("Materials/M2");
    }


    /// <summary>
    /// Changes the skybox to use material one .
    /// </summary>
    public void ChangeToMaterialOne()
    {
        RenderSettings.skybox = _materialOne;
    }


    /// <summary>
    /// Changes the skybox to use the 360 photosphere texture material
    /// </summary>
    /// <param name="sphereName">Name of the texture/image to display in the 360 skybox</param>
    public void ChangeToMaterialTwo(string sphereName)
    {
        string path = "PhotoSpheres/" + sphereName;
        Texture t = Resources.Load<Texture>(path);
        if (t != null)
        {
            _materialTwo.mainTexture = t;
            RenderSettings.skybox = _materialTwo;
        }
    }
}