using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{

    void OnMouseUpAsButton()
    {
        int coinsAmount = PlayerPrefs.GetInt("coinsAmount");

        PlayerPrefs.SetInt("coinsAmount", coinsAmount + 30);
    }

    }
