using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string isBoughtGiantBalloon;
    public string isBoughtGoldenGiantBalloon;
    public string isBoughtRocket;

    public GameObject giantBalloon;
    public GameObject giantBalloon2;
    public GameObject giantBalloon3;

    void Start()
    {
        giantBalloon = GameObject.Find("GiantBalloon");
        giantBalloon2 = GameObject.Find("GiantBalloon2");
        giantBalloon3 = GameObject.Find("GiantBalloon3");

        isBoughtGiantBalloon = PlayerPrefs.GetString("GiantBalloon");
        isBoughtGoldenGiantBalloon = PlayerPrefs.GetString("GoldenGiantBalloon");
        isBoughtRocket = PlayerPrefs.GetString("RocketCost");

        if(isBoughtGiantBalloon == "bought")
        {
            giantBalloon.transform.position = new Vector3(2, 13, 1);
            giantBalloon2.transform.position = new Vector3(-4, 122, 1);
            giantBalloon3.transform.position = new Vector3(0, 230, 1);
        }
/*        if (isBoughtGoldenGiantBalloon == "bought")
        {

        }
        if (isBoughtRocket == "bought")
        {

        }*/
    }


}
