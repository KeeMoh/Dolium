using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class END : MonoBehaviour
{

    public bool isEndGame = false;
    private bool loadEndGame = false;
    public GameObject FadeIn;
    public StarterAssets.StarterAssetsInputs _input;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if ((isEndGame) && !loadEndGame)
        {
            skip();
        }
    }

    IEnumerator backMainMenu()
    {
        FadeIn.SetActive(true);

        FadeIn.GetComponent<Animator>().SetTrigger("fadein");

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainMenu");

        yield break;

    }

    public void skip()
    {
        loadEndGame = true;
        StartCoroutine(backMainMenu());
    }
}
