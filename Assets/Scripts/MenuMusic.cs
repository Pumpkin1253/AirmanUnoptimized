using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMusic : MonoBehaviour
{
    public string music;
    public AudioSource audio;
   
    int i = 0;
    int j = 0;
    void Awake()
    {
        music = PlayerPrefs.GetString("music");
        audio = GetComponent<AudioSource>();
        if (music == "")
        {
            music = "on";
            PlayerPrefs.SetString("music", "on");
        }
        if (music == "on" && j ==0)
        {
            j += 1;
            Debug.Log("awake");
            audio.Play();
            GameObject[] objs = GameObject.FindGameObjectsWithTag("MainMusic");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Update()
    {
        audio = GetComponent<AudioSource>();
        music = PlayerPrefs.GetString("music");
      
        if (SceneManager.GetActiveScene().name == "Game" &&  music == "on")
        {
            Destroy(this.gameObject);
        }

        if (music == "off" && i == 1)
        {
            Debug.Log("off");
            i = 0;
            audio.Stop();
           // Destroy(this.gameObject);
           
        }
        if (music == "on" && i == 0)
        {
            
            Debug.Log("on");
            i += 1;
           
                audio.Play();
        }
    }


}
