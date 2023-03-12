using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Settings : MonoBehaviour
{

    public GameObject prev;
    public  GameObject next;
    public GameObject aclrmtr;
    public GameObject btns;

    public GameObject SoundBtn;
    public GameObject MusicBtn;
    public GameObject NoSoundBtn;
    public GameObject NoMusicBtn;

    public string status;
    public string sound;
    public string music;

    public int timesInOptions = 0;

    public GameObject text0;
    public GameObject text1;

    public bool text0DownPlayed;
    public bool text1DownPlayed;

    void Start()
    {
         prev = GameObject.Find("prev");
         next = GameObject.Find("next");
         aclrmtr = GameObject.Find("accelerometer");
         btns = GameObject.Find("Buttons");

         SoundBtn = GameObject.Find("Sounds");
         MusicBtn = GameObject.Find("Music");
         NoSoundBtn = GameObject.Find("NoSounds");
         NoMusicBtn = GameObject.Find("NoMusic");

         status = PlayerPrefs.GetString("status");

         sound = PlayerPrefs.GetString("sound");

         music = PlayerPrefs.GetString("music");

         text0 = GameObject.Find("text0");
         text1 = GameObject.Find("text1");

        text0DownPlayed = false;
        text1DownPlayed = false;

        timesInOptions = PlayerPrefs.GetInt("timesInOptions");

                if(timesInOptions == 0)
         {      
              PlayerPrefs.SetInt("timesInOptions", 1);
              StartCoroutine(waiterText0());
         }




       switch (status)
         {
             case "off":
                 prev.transform.localScale = new Vector3(0, 0, 1);
                 next.transform.localScale = new Vector3(0.1020563f, 0.1020563f, 1);

                 aclrmtr.transform.localScale = new Vector3(0, 0, 1);
                 btns.transform.localScale = new Vector3(0.638242f, 0.638242f, 1);
                 break;

             case "on":
                  prev.transform.localScale = new Vector3(0.1020563f, 0.1020563f, 1);
                 next.transform.localScale = new Vector3(0, 0, 1);

                 aclrmtr.transform.localScale = new Vector3(0.50f, 0.50f, 1); // 0.5485549f not beta
                 btns.transform.localScale = new Vector3(0, 0, 1);
                 break;
         }

         switch (sound)
         {
             case "off":
                 SoundBtn.transform.localPosition = new Vector3(-0.99f, 7.03f, 1); // out of view

                 NoSoundBtn.transform.localPosition = new Vector3(-0.99f, 3.98f, 1);
                 break;

             case "on":
                 SoundBtn.transform.localPosition = new Vector3(-0.99f, 3.98f, 1);

                 NoSoundBtn.transform.localPosition = new Vector3(-0.99f, 7.03f, 1);// out of view
                 break;
         }

         switch (music)
         {
             case "off":
                 MusicBtn.transform.localPosition = new Vector3(1.211f, 7.03f, 1); // out of view

                 NoMusicBtn.transform.localPosition = new Vector3(1.211f, 3.98f, 1);
                 break;

             case "on":
                 MusicBtn.transform.localPosition = new Vector3(1.211f, 3.98f, 1);

                 NoMusicBtn.transform.localPosition = new Vector3(1.211f, 7.03f, 1);  // out of view
                 break;
         }

    }

    void Update()
    {
        timesInOptions = PlayerPrefs.GetInt("timesInOptions");
    }

void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
         
            case "next":
                PlayerPrefs.SetString("status", "on");  // acc on

                prev.transform.localScale = new Vector3(0.1020563f, 0.1020563f, 1);
                next.transform.localScale = new Vector3(0, 0, 1);

                aclrmtr.transform.localScale = new Vector3(0.50f, 0.50f, 1); // 0.5485549f not beta
                btns.transform.localScale = new Vector3(0, 0, 1);

                if (timesInOptions == 1)
                {
                    PlayerPrefs.SetInt("timesInOptions", 2);
                    StartCoroutine(waiterNext());
                }
                
                break;

            case "prev":
                PlayerPrefs.SetString("status", "off"); // acc off

                prev.transform.localScale = new Vector3(0, 0, 1);
                next.transform.localScale = new Vector3(0.1020563f, 0.1020563f, 1);

                aclrmtr.transform.localScale = new Vector3(0, 0, 1);
                btns.transform.localScale = new Vector3(0.638242f, 0.638242f, 1);

                if (timesInOptions == 2)
                {
                    PlayerPrefs.SetInt("timesInOptions", 10);
                    StartCoroutine(waiterText1Down());
                }
               
                break;

            case "Sounds":

                PlayerPrefs.SetString("sound", "off");

                SoundBtn.transform.localPosition = new Vector3(-0.99f, 7.03f, 1); // out of view

                NoSoundBtn.transform.localPosition = new Vector3(-0.99f, 3.98f, 1); 

                break;

            case "Music":
                PlayerPrefs.SetString("music", "off");

                MusicBtn.transform.localPosition = new Vector3(1.211f, 7.03f, 1); // out of view

                NoMusicBtn.transform.localPosition = new Vector3(1.211f, 3.98f, 1);
                break;

            case "NoSounds":

                PlayerPrefs.SetString("sound", "on");

                SoundBtn.transform.localPosition = new Vector3(-0.99f, 3.98f, 1); 

                NoSoundBtn.transform.localPosition = new Vector3(-0.99f, 7.03f, 1);// out of view

                break;

            case "NoMusic":
                PlayerPrefs.SetString("music", "on");

                MusicBtn.transform.localPosition = new Vector3(1.211f, 3.98f, 1);

                NoMusicBtn.transform.localPosition = new Vector3(1.211f, 7.03f, 1);  // out of view
                break;

            case "text0_1":
                if (text0DownPlayed == false)
                {
                    text0DownPlayed = true;
                    StartCoroutine(waiterText0Down());                    
                }

                break;

            case "text1_1":
                StartCoroutine(waiterText1Down());

                break;

            default:
                Debug.Log("Smth went wrong");
                break;

        }
    }
    IEnumerator waiterText0() // for playing death anima
    {
        text0.transform.localPosition = new Vector3(0, -7.8f, 0.0f);
        text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("main");

        yield return new WaitForSecondsRealtime(20.5f);

        text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
        text0.transform.localPosition = new Vector3(15, 1, 0.0f);
    }

    IEnumerator waiterText0Down()
    {

            text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("down");

            yield return new WaitForSecondsRealtime(0.5f);

            text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
             text0.transform.localPosition = new Vector3(15, 1, 0.0f);
    }

    IEnumerator waiterNext()
    {
        if (text0DownPlayed == false)
        {
            text0DownPlayed = true;
            StartCoroutine(waiterText0Down());
        }

        text1.transform.localPosition = new Vector3(0, -6.8f, 0.0f);
        text1.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("main");

        yield return new WaitForSecondsRealtime(20.5f);

        text1.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
        text0.transform.localPosition = new Vector3(15, 1, 0.0f);
    }

    IEnumerator waiterText1Down()
    {
        if (text1DownPlayed == false)
        {
            text1.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("down");

            yield return new WaitForSecondsRealtime(0.8f);

            text1.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
            text0.transform.localPosition = new Vector3(15, 1, 0.0f);
            text1DownPlayed = true;
        }
    }
}
