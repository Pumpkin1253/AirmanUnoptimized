using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        AsyncOperation asyncOperation1 = SceneManager.LoadSceneAsync("Menu");
        asyncOperation1.allowSceneActivation = false;


        yield return new WaitForSeconds(68);
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        // later, in response to some input...
        if (Input.GetMouseButton(0))
        {
            StopCoroutine(waiter());
            SceneManager.LoadScene("Menu");
        }
    }
}
