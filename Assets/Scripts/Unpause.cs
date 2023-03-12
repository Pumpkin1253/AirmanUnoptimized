using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpause : MonoBehaviour
{
    GameObject pausecanvas;
    GameObject pausepic;

    void Start()
    {
        pausecanvas = GameObject.Find("PauseCanvas");
    }
        public void OnMouseDown()
    {
        pausecanvas.SetActive(false);
        Time.timeScale = 1;
        //  transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
}
