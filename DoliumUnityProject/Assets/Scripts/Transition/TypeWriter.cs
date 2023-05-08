using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriter : MonoBehaviour
{
    string finalText4;
    public Text text4;
    public bool isStartingGame;
    int numScene;
    public float delai = 0.2f;
    AudioSource audiosource;

    Animator delayBeforeChangingScene;
    public Animator fadein;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        if (isStartingGame)
        {
            numScene = 0;
        } else
        {
            numScene = PlayerPrefs.GetInt("idscene");
        }
        delayBeforeChangingScene = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        text4.text = null;
        switch (numScene)
        {
            case 0:
                finalText4 = "I - Découverte amnésique";
                StartCoroutine(ShowLetterByLetter());
                break;
            case 1:
                finalText4 = "II - Profonde mélancolie";
                StartCoroutine(ShowLetterByLetter());
                break;
            case 2:
                finalText4 = "III - Nouveau départ";
                StartCoroutine(ShowLetterByLetter());
                break;
        }
    }

    IEnumerator ShowLetterByLetter()
    {

        for (int i=0; i <= finalText4.Length; i++)
        {
            text4.text = finalText4.Substring(0, i);

            if(i < finalText4.Length)
            {
                if (finalText4.Substring(i,1) != " ")
                {
                    audiosource.pitch = Random.Range(0.95f, 1.05f);
                    audiosource.Play();
                }
            }
            yield return new WaitForSeconds(delai);
        }

        switch (numScene)
        {
            case 0:
                ChangeScene.sceneName = "Scene1";
                break;
            case 1:
                ChangeScene.sceneName = "Scene2";
                break;
            case 2:
                ChangeScene.sceneName = "Scene3";
                break;
        }

        fadein.SetBool("start", true);
        delayBeforeChangingScene.SetBool("start", true);
        yield return new WaitForSeconds(5);

    }

}
