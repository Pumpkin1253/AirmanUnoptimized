using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;


public class DefaultSettings : MonoBehaviour
{
    public string status;
    public string sound;
    public string music;

    public string isBoughtGiantBalloon;
    public string isBoughtGoldenGiantBalloon;
    public string isBoughtRocket;

    void Start()
    {
        status = PlayerPrefs.GetString("status");
        sound = PlayerPrefs.GetString("sound");
        music = PlayerPrefs.GetString("music");


        

        if (status == "")
        {
            PlayerPrefs.SetInt("timesInOptions", 0);
            PlayerPrefs.SetInt("timesInShop", 0);
            PlayerPrefs.SetInt("timesInGame", 0);

            PlayerPrefs.SetString("status", "off");
            
        }
        
        if (sound == "")
        {
            PlayerPrefs.SetString("sound", "on");
        }
       
        if (music == "")
        {
            PlayerPrefs.SetString("music", "on");
        }


        isBoughtGiantBalloon = PlayerPrefs.GetString("GiantBalloon");
        isBoughtGoldenGiantBalloon = PlayerPrefs.GetString("GoldenGiantBalloon");
        isBoughtRocket = PlayerPrefs.GetString("RocketCost");

        if (isBoughtGiantBalloon == "")
        {
            PlayerPrefs.SetString("GiantBalloon", "notBought");
        } 
/*        else { }
        if (isBoughtGoldenGiantBalloon == "")
        {
            PlayerPrefs.SetString("GiantBalloon", "notBought");
        }
        else { }
        if (isBoughtRocket == "")
        {
            PlayerPrefs.SetString("GiantBalloon", "notBought");
        }
        else { }*/

    }


}
