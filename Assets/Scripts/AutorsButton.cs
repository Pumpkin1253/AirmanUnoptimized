using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutorsButton : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {

            case "Back":
                Application.LoadLevel("Setting");
                break;



        }
    }
}
