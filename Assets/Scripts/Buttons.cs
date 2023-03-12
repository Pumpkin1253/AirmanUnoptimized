using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public GameObject m_on, m_off;
    public GameObject S_on, S_off;

    public AudioSource audioSource;
    public string Sounds;

        void Start()
        {
        audioSource = GetComponent<AudioSource>();
        Sounds = PlayerPrefs.GetString("sound");

    }


    IEnumerator waiter(string scene)
    {

        GameObject armatureComponent = GameObject.Find("Menu");

        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("Perehod");

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene(scene);
    }


    [System.Obsolete]
    void OnMouseUpAsButton()
    {
        //GameObject.Find("ClickAudio").GetComponent<AudioSource>().Play();
        checkSoundClick();
        switch (gameObject.name)
        {
            

            case "Play":
                StartCoroutine(waiter("Loading")); // func for playing anima of main menu
                break;
            case "New game":
                Time.timeScale = 1;
                SceneManager.LoadScene("Loading");
                break;
            case "Options":
                
                StartCoroutine(waiter("Options")); //  func for playing anima of main menu
                break;
            case "Exit":
               
                Application.Quit();
                break;
            case "Creators":
                
                SceneManager.LoadScene("Creators");
                break;
            case "Shop":
                
                SceneManager.LoadScene("Shop");
                break;
            case "MainMenu":
                Time.timeScale = 1;
                
                SceneManager.LoadScene("LoadingToMenu");
                break;
            case "BackFromOptions":
              
                SceneManager.LoadScene("Menu");
                break;
            case "BackFromCreators":
               
                SceneManager.LoadScene("Menu");
                break;
            case "BackFromShop":
                
                SceneManager.LoadScene("Menu");
                break;
            case "Won":
                SceneManager.LoadScene("LoadingFromWon");
                break;
            case "ADS":
                SceneManager.LoadScene("ADS");
                break;
            case "BackFromADS":
                SceneManager.LoadScene("Menu");
                break;
                /*            case "Music":
                                if (PlayerPrefs.GetString("Music") != "no")
                                {
                                    PlayerPrefs.SetString("Music", "no");
                                    m_on.SetActive(false);
                                    m_off.SetActive(true);
                                }
                                else
                                {
                                    GameObject.Find("ClickAudio").GetComponent<AudioSource>().Stop();
                                    PlayerPrefs.SetString("Music", "yes");
                                    m_on.SetActive(true);
                                    m_off.SetActive(false);
                                }
                                break;
                            case "Song":
                                if (PlayerPrefs.GetString("Song") != "no")
                                {
                                    GameObject.Find("SongTrack").GetComponent<AudioSource>().Play();
                                    PlayerPrefs.SetString("Song", "no");
                                    S_on.SetActive(true);
                                    S_off.SetActive(false);
                                }
                                else
                                {
                                    GameObject.Find("SongTrack").GetComponent<AudioSource>().Stop();
                                    PlayerPrefs.SetString("Song", "yes");
                                    S_on.SetActive(false);
                                    S_off.SetActive(true);
                                }
                                break;*/
        }
    }


    void checkSoundClick()
    {
        if(Sounds == "on")
        audioSource.Play();
    }

    void Update()
    {

    }


}

