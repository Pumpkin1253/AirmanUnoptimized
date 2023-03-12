using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RecordScore : MonoBehaviour
{
    public Text recordScore;

    void Start()
    {
        recordScore.text = PlayerPrefs.GetInt("recordScore").ToString();
    }


}
