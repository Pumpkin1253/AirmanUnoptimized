using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AmountCoins : MonoBehaviour
{
    public Text coinsAmount;

    void Start()
    {
        coinsAmount.text = PlayerPrefs.GetInt("coinsAmount").ToString();
    }

    void Update()
    {
        coinsAmount.text = PlayerPrefs.GetInt("coinsAmount").ToString();
    }

}
