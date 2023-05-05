using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject settings;
    public GameObject commandes;
    public Animator startGameAnim;
    public bool startGame;
    public bool loading;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        startGame = false;
        loading = false;
    }

    private void Update()
    {
        if (!loading)
        {
            if (startGame)
            {
                loading = true;
                SceneManager.LoadScene("FirstTransition");
            }
        }
    }

    public void PlayGame()
    {
        startGameAnim.SetBool("start", true);
    }

    public void BackMenu()
    {
        mainmenu.SetActive(true);
        settings.SetActive(false);
        commandes.SetActive(false);
    }

    /*public void BackSettings()
    {
        settings.SetActive(true);
        commandes.SetActive(false);
    }

    public void GoToSettingMenu()
    {
        settings.SetActive(true);
        mainmenu.SetActive(false);
    }*/

    public void ShowCommandes()
    {
        mainmenu.SetActive(false);
        commandes.SetActive(true);
        settings.SetActive(false);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Generique_final");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}