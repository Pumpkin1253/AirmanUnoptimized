using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMusic : MonoBehaviour
{
    public string music;
    public AudioSource audio;

    void Awake()
    {
        music = PlayerPrefs.GetString("music");
        audio = GetComponent<AudioSource>();

        if (music == "on")
        {
            audio.Play();
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Menu" && music == "on")
        {
            Destroy(this.gameObject);
        }
    }
}
