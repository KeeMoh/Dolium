using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class BreakMenu : MonoBehaviour
{

    public GameObject pauseCanvas;
    public GameObject pausemenu;
    //public GameObject settings;
    public GameObject commandes;
    public GameObject confirmQuit;
    public bool isActive;
    private StarterAssets.StarterAssetsInputs _input;
    public Collider player;
    public AudioSource musicEnv;
    private bool onpause;
    public GameObject followcam;

    private void Start()
    {
        isActive = false;
        onpause = false;
        _input = player.GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    private void Update()
    {
        if (isActive)
        {
            if (!onpause)
            {
                onpause = true;
                pauseCanvas.SetActive(true);
                pausemenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
                musicEnv.Pause();
                followcam.SetActive(false);
            }
        }
        else
        {
            if (onpause)
            {
                onpause = true;
                pauseCanvas.SetActive(false);
                pausemenu.SetActive(false);
                commandes.SetActive(false);
                confirmQuit.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                onpause = false;
                musicEnv.Play();
                followcam.SetActive(true);
            }
        }

        if (_input.pause)
        {
            stateActiveBreakMenu();
            _input.pause = false;
        }
        
    }

    public void stateActiveBreakMenu()
    {
        isActive = !isActive;
    }

    public void BackMenu()
    {
        confirmQuit.SetActive(false);
        pausemenu.SetActive(true);
        //settings.SetActive(false);
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
        pausemenu.SetActive(false);
    }*/

    public void ShowCommandes()
    {
        pausemenu.SetActive(false);
        commandes.SetActive(true);
        //settings.SetActive(false);
    }

    public void ShowConfimQuitGame()
    {
        confirmQuit.SetActive(true);
        pausemenu.SetActive(false);
        //settings.SetActive(false);
        commandes.SetActive(false);
    }

    public void ConfirmQuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
