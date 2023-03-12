using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{


    GameObject pausecanvas;

    void Start()
    {
        pausecanvas = GameObject.Find("PauseCanvas");
        pausecanvas.SetActive(false);
        
    }


    public void OnMouseDown()
    {
        Time.timeScale = 0;
        pausecanvas.SetActive(true);
        
    }

}
