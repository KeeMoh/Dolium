using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriter : MonoBehaviour
{
    string finalText1;
    string finalText2;
    string finalText3;
    string finalText4;
    public Text text1;
    public Text text2;
    public Text text3;
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
        text1.text = null;
        text2.text = null;
        text3.text = null;
        text4.text = null;
        switch (numScene)
        {
            case 0:
                finalText1 = "";
                finalText2 = "";
                finalText3 = "";
                finalText4 = "I - Découverte amnésique";
                StartCoroutine(ShowLetterByLetter());
                break;
            case 1:
                //finalText4 = "II - Pulsions Colériques";
                finalText1 = "";
                finalText2 = "";
                finalText3 = "";
                finalText4 = "II - Profonde mélancolie";
                StartCoroutine(ShowLetterByLetter());
                break;
            case 2:
                //finalText4 = "III - Douce mélancolie";
                finalText1 = "";
                finalText2 = "";
                finalText3 = "";
                finalText4 = "III - Nouveau départ";
                StartCoroutine(ShowLetterByLetter());
                break;
            case 3:
                //finalText4 = "IV - Décision aprobative";
                finalText1 = "'Le deuil est un lâcher prise que personne d'autre que toi ne peut faire'";
                finalText2 = "Steve Lambert";
                finalText3 = "Cela ne veut pas pour tant dire que tu es seul(e) à traverser cette période difficile...";
                finalText4 = "Même dans la douleur, tu dois continuer d'aller de l'avant car : \n'Le malheur de l'avoir perdu ne doit pas te faire oublier le bonheur de l'avoir connu.'";
                StartCoroutine(ShowFinalLetterByLetter());
                break;
            //case 4:
                //finalText4 = "V - Nouveau départ";
                //break;
            //case 5:
               // finalText = "";
               // break;
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
                //case 3:
                //SceneManager.LoadScene("Scene4");
                //ChangeScene.sceneName = "Scene4";
                //break;
                //case 4:
                //SceneManager.LoadScene("Scene5");
                //ChangeScene.sceneName = "Scene5";
                // break;
        }

        fadein.SetBool("start", true);
        delayBeforeChangingScene.SetBool("start", true);
        yield return new WaitForSeconds(5);

    }

    IEnumerator ShowFinalLetterByLetter()
    {

        for (int i = 0; i <= finalText1.Length; i++)
        {
            text1.text = finalText1.Substring(0, i);

            if (i < finalText1.Length)
            {
                if (finalText1.Substring(i, 1) != " ")
                {
                    audiosource.pitch = Random.Range(0.95f, 1.05f);
                    audiosource.Play();
                }
            }
            yield return new WaitForSeconds(delai);
        }

        for (int i = 0; i <= finalText2.Length; i++)
        {
            text2.text = finalText2.Substring(0, i);

            if (i < finalText2.Length)
            {
                if (finalText2.Substring(i, 1) != " ")
                {
                    audiosource.pitch = Random.Range(0.95f, 1.05f);
                    audiosource.Play();
                }
            }
            yield return new WaitForSeconds(delai);
        }

        for (int i = 0; i <= finalText3.Length; i++)
        {
            text3.text = finalText3.Substring(0, i);

            if (i < finalText3.Length)
            {
                if (finalText3.Substring(i, 1) != " ")
                {
                    audiosource.pitch = Random.Range(0.95f, 1.05f);
                    audiosource.Play();
                }
            }
            yield return new WaitForSeconds(delai);
        }

        for (int i = 0; i <= finalText4.Length; i++)
        {
            text4.text = finalText4.Substring(0, i);

            if (i < finalText4.Length)
            {
                if (finalText4.Substring(i, 1) != " ")
                {
                    audiosource.pitch = Random.Range(0.95f, 1.05f);
                    audiosource.Play();
                }
            }
            yield return new WaitForSeconds(delai);
        }

        ChangeScene.sceneName = "Generique";       

        yield return new WaitForSeconds(5);

    }
}
