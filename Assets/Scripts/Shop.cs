using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject prev;
    public GameObject next;

    public GameObject giantBalloon;
    public GameObject giantBalloonDescr;
    public GameObject goldenGiantBalloon;
    public GameObject goldenGiantBalloonDescr;
    public GameObject rocket;
    public GameObject rocketDescr;

    public GameObject giantBalloonCost;
    public GameObject goldenGiantBalloonCost;
    public GameObject rocketCost;

    public string isBoughtGiantBalloon;
    public string isBoughtGoldenGiantBalloon;
    public string isBoughtRocket;

    public int i;
    public int j;

    public bool isNotEnoughCoinsAnimaPlayed = true;
    public int coinsAmount;

    public int timesInShop = 0;
    public GameObject text0;

    void Start()
    {
        PlayerPrefs.SetInt("i", 0);

        prev = GameObject.Find("prev");
        next = GameObject.Find("next");

        giantBalloon = GameObject.Find("GiantBalloon");
        giantBalloonDescr = GameObject.Find("GiantBalloonDescr");
        giantBalloonCost = GameObject.Find("GiantBalloonCost");

        goldenGiantBalloon = GameObject.Find("GoldenGiantBalloon");
        goldenGiantBalloonDescr = GameObject.Find("GoldenGiantBalloonDescr");
        goldenGiantBalloonCost = GameObject.Find("GoldenGiantBalloonCost");

        rocket = GameObject.Find("Rocket");
        rocketDescr = GameObject.Find("RocketDescr");
        rocketCost = GameObject.Find("RocketCost");


        isBoughtGiantBalloon = PlayerPrefs.GetString("GiantBalloon"); 
        isBoughtGoldenGiantBalloon = PlayerPrefs.GetString("GoldenGiantBalloon");
        isBoughtRocket = PlayerPrefs.GetString("RocketCost");

        coinsAmount = PlayerPrefs.GetInt("coinsAmount");

        giantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);
        giantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);

        if (isBoughtGiantBalloon == "bought")
        {
            giantBalloonCost.transform.localScale = new Vector3(0, 0, 1);
        }

        text0 = GameObject.Find("text0");
        timesInShop = PlayerPrefs.GetInt("timesInShop");

        if (timesInShop == 0)
        {
            PlayerPrefs.SetInt("timesInShop", 1);
            StartCoroutine(waiterText0());
        }
    }

    void Update()
    {
        timesInShop = PlayerPrefs.GetInt("timesInShop");
        coinsAmount = PlayerPrefs.GetInt("coinsAmount");
    }

    void OnMouseUpAsButton()
    {
        i = PlayerPrefs.GetInt("i");
        switch (gameObject.name)
        {
            
            case "next":

                switch (i)
                {
                    case 0:
                        prev.transform.position = new Vector3(-2.26f, 0.06f, 1);
                        next.transform.position = new Vector3(2.35f, 0.07f, 1);

                        giantBalloon.transform.position = new Vector3(15, 1, 1);
                        giantBalloonDescr.transform.position = new Vector3(15, 1, 1);
                        giantBalloonCost.transform.position = new Vector3(15, 1, 1);

                        goldenGiantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);
                        goldenGiantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                        i = 1; // na 1
                        PlayerPrefs.SetInt("i", i); 
                        break;

                    case 1:
                        next.transform.position = new Vector3(15, 1, 1);
                        goldenGiantBalloon.transform.position = new Vector3(15, 1, 1);
                        goldenGiantBalloonDescr.transform.position = new Vector3(15, 1, 1);
                        goldenGiantBalloonCost.transform.position = new Vector3(15, 1, 1);

                        rocket.transform.position = new Vector3(0.02f, 0.03f, 1);
                        rocketCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                        i = 2; //na 2
                        PlayerPrefs.SetInt("i", i);
                        break;

                }
                break;

            case "prev":
                switch (i)
                {
                    case 1:
                        prev.transform.position = new Vector3(15,1, 1);

                        giantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);
                        giantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                        goldenGiantBalloonCost.transform.position = new Vector3(15, 1, 1);
                        goldenGiantBalloonDescr.transform.position = new Vector3(15, 1, 1);
                        goldenGiantBalloon.transform.position = new Vector3(15, 1, 1);

                        i = 0; // na 0
                        PlayerPrefs.SetInt("i", i);
                        break;

                    case 2:
                        prev.transform.position = new Vector3(-2.26f, 0.06f, 1);
                        next.transform.position = new Vector3(2.35f, 0.07f, 1);

                        goldenGiantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);
                        goldenGiantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);

                        rocketCost.transform.position = new Vector3(15, 1, 1);
                        rocketDescr.transform.position = new Vector3(15, 1, 1);
                        rocket.transform.position = new Vector3(15, 1, 1);

                        i = 1;// na 1
                        PlayerPrefs.SetInt("i", i);
                        break;

                }
                break;

            case "GiantBalloon":
                giantBalloonDescr.transform.position = new Vector3(0.02f, 0.03f, 1);

                giantBalloon.transform.position = new Vector3(15, 1, 1);
                giantBalloonCost.transform.position = new Vector3(15, 1, 1);
                break;

            case "GiantBalloonDescr":
                giantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);
                giantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                giantBalloonDescr.transform.position = new Vector3(15, 1, 1);
                break;

            case "GoldenGiantBalloon":
                goldenGiantBalloonDescr.transform.position = new Vector3(0.02f, 0.03f, 1);
                goldenGiantBalloon.transform.position = new Vector3(15, 1, 1);
                goldenGiantBalloonCost.transform.position = new Vector3(15, 1, 1);
                break;

            case "GoldenGiantBalloonDescr":
                goldenGiantBalloon.transform.position = new Vector3(0.02f, 0.03f, 1);
                goldenGiantBalloonCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                goldenGiantBalloonDescr.transform.position = new Vector3(15, 1, 1);
                break;

            case "Rocket":
                rocketDescr.transform.position = new Vector3(0.02f, 0.03f, 1);
                rocket.transform.position = new Vector3(15, 1, 1);
                rocketCost.transform.position = new Vector3(15, 1, 1);
                break;

            case "RocketDescr":
                rocket.transform.position = new Vector3(0.02f, 0.03f, 1);
                rocketCost.transform.position = new Vector3(0.009f, -1.294f, 1);

                rocketDescr.transform.position = new Vector3(15, 1, 1);
                break;

            case "GiantBalloonCost":

                if (isBoughtGiantBalloon == "notBought" && coinsAmount >= 30)
                {

                    PlayerPrefs.SetString("GiantBalloon", "bought");

                    PlayerPrefs.SetInt("coinsAmount", coinsAmount - 30);
                    giantBalloonCost.transform.localScale = new Vector3(0, 0, 1);
                }
                if (coinsAmount < 30 && isNotEnoughCoinsAnimaPlayed == true)
                {
                    isNotEnoughCoinsAnimaPlayed = false;
                    StartCoroutine(waiterGiantBalloon());
                }
                break;

            case "GoldenGiantBalloonCost":
                if (isBoughtGoldenGiantBalloon == "notBought")
                    PlayerPrefs.SetString("GoldenGiantBalloon", "bought");
                break;

            case "RocketCost":
                if (isBoughtRocket == "notBought")
                    PlayerPrefs.SetString("GoldenGiantBalloon", "bought");
                break;

            case "text0_2":
               // PlayerPrefs.SetInt("timesInShop", 1);
                StartCoroutine(waiterText0Down());
                break;
        }
    }


    IEnumerator waiterGiantBalloon()
    {
        GameObject armatureComponent = GameObject.Find("NotEnoughCoins");
        armatureComponent.transform.localPosition = new Vector3(0, -5.7f, 1);
        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("animtion0");

        yield return new WaitForSecondsRealtime(6.30f);

        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
        isNotEnoughCoinsAnimaPlayed = true;
    }

    IEnumerator waiterText0() // for playing death anima
    {
        text0.transform.localPosition = new Vector3(0, -6.3f, 0.0f);
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

}
