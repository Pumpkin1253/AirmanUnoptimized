using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtons : MonoBehaviour
{
    void OnMouseUpAsButton()
    {

        switch (gameObject.name)
        {

            case "MainMenu":
                SceneManager.LoadScene("Menu");
                break;
            case "Restart":
                SceneManager.LoadScene("Game");
                break;

        }
    }
}