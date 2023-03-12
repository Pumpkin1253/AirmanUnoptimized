
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float playerSpeed;
    public float jumpPower;
    public float directionInput;
    public bool facingRight = true;
    public int acceleration;
    public float force = 10.0f;
    public Text scoreText;
    public static int score;
    public static int lives;
    public GameObject live_1;
    public GameObject live_2;
    public GameObject live_3;
    public bool canBeDamaged = true;

    public string status;
    public Text acm;

    public bool isPlayedGiantBalloonAnima;
    public bool isPlayedDamageAnima;

    public int timesInGame = 0;
    public GameObject text0;

    void Start()
    {
        isPlayedGiantBalloonAnima = false;
        isPlayedDamageAnima = false;
        GameObject RightBtn = GameObject.Find("Right");
        GameObject LeftBtn = GameObject.Find("Left");

        rb = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        canBeDamaged = true;

        status = PlayerPrefs.GetString("status");

        if (status == "on")
        {
            RightBtn.transform.localScale = new Vector3(0, 0, 1);
            LeftBtn.transform.localScale = new Vector3(0, 0, 1);
        }

        // Input armature name
        GameObject armatureComponent = GameObject.Find("Hero");

        // Play animation.
        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("flying");

        // Change armatureposition.
        armatureComponent.transform.localPosition = new Vector3(0, -2, 0.0f);
        armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);

        text0 = GameObject.Find("text0");
        timesInGame = PlayerPrefs.GetInt("timesInGame");
        if (timesInGame != 0)
            text0.transform.localPosition = new Vector3(15, 1, 0.0f);

        if (timesInGame == 0)
        {
            jumpPower = 0.2f;
            PlayerPrefs.SetInt("timesInGame", 1);
            StartCoroutine(waiterText0());

        }
    }
    public void JustUp()
    {
        if (isPlayedGiantBalloonAnima == false && isPlayedDamageAnima == false)
        {
            GameObject armatureComponent = GameObject.Find("Hero");

            armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("flying");

            armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }
    }

    public void OnMouseClickLeft() 
    {
        if (isPlayedGiantBalloonAnima == false && isPlayedDamageAnima == false)
        {
            GameObject armatureComponent = GameObject.Find("Hero");

            armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("toTheLeft");
            armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }

    }

    public void OnMouseClickRight()
    {
        if (isPlayedGiantBalloonAnima == false && isPlayedDamageAnima == false)
        {
            GameObject armatureComponent = GameObject.Find("Hero");

            armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("toTheRight");
            armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        }
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        //  PlayerPrefs.SetInt("Score ", scoregame);
        //    PlayerPrefs.Save();
        //    Debug.Log("Save");

            //    recordgame = PlayerPrefs.GetInt("Score ", scoregame);
            /* Vector3 dir = new Vector3(Input.acceleration.x,0,Input.acceleration.y);
              transform.Translate(dir * 10f * Time.deltaTime);
            */

    }

    void FixedUpdate()
    {

       
        if (status == "off")
        {
            rb.velocity = new Vector2(playerSpeed * directionInput, rb.velocity.y);
        }
        if (status == "on")
        {
            GameObject armatureComponent = GameObject.Find("Hero");
            armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);

            Vector2 acceleration = Input.acceleration;
            rb.velocity = new Vector2(playerSpeed * acceleration.x, rb.velocity.y);
            acm.text = acceleration.x.ToString();

            if (acceleration.x < 0)
            {

                armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("toTheRight");
            }
            else
            {
                armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("toTheLeft");
            }

        }
    }

    public void Move(float InputAxis)
    {

        if(status == "off")
        directionInput = InputAxis;

    }


    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Star")
        {

            Destroy(collision.gameObject);

            score++;
            scoreText.text = score.ToString();

        }

    }
/*    void OnGUI()
    {


        GUI.Box(new Rect(0, 0, 100, 100), "Stars: " + recordgame);


    }
*/
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (((collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Pl") && canBeDamaged) && lives>0) {
            //Debug.Log(lives);
            isPlayedDamageAnima = true;
            lives--;
            StartCoroutine(waiterDamage());

            if (lives == 2)
            {
                live_3.SetActive(false);
            }
            if (lives == 1)
            {
                live_2.SetActive(false);
            }
            if (lives == 0)
            {
                live_1.SetActive(false);
            }
        }

        if (lives == 0) {
            StopAllCoroutines();
            Debug.Log("DEAD");
            canBeDamaged = false;
    //        rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition; // freeze the hero

            GameObject pause = GameObject.Find("Pause");
            GameObject rightBtn = GameObject.Find("Right");
            GameObject leftBtn = GameObject.Find("Left");

            pause.SetActive(false);
            rightBtn.SetActive(false);
            leftBtn.SetActive(false);


            StartCoroutine(waiter());// for playing death anima
            saveRecordScore();
            saveCoinsAmount();
        }

        if (collision.gameObject.tag == "Win")
        {
            saveRecordScore();
            saveCoinsAmount();
            SceneManager.LoadScene("Win");
        }

        if (collision.gameObject.tag == "GiantBalloon")
        {
            isPlayedGiantBalloonAnima = true;

            Destroy(collision.gameObject);
            StartCoroutine(waiterGiantBalloon());// for playing GiantBalloon anima
        }

/*        if (collision.gameObject.tag == "GoldenGiantBalloon")
        {

        }

        if (collision.gameObject.tag == "Rocket")
        {

        }*/
    }

    IEnumerator waiterGiantBalloon()
    {
        rb.isKinematic = true;
        canBeDamaged = false;
        jumpPower = 8f;
        GameObject armatureComponent = GameObject.Find("Hero");
        armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("GiantBalloon_v3");

        yield return new WaitForSecondsRealtime(4);

        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("flying");
        canBeDamaged = true;
        rb.isKinematic = false;
        jumpPower = 5f;
        isPlayedGiantBalloonAnima = false;
    }

    IEnumerator waiterDamage() // for waiting damage
    {
 //       rb.isKinematic = true;
        canBeDamaged = false;
        GameObject armatureComponent = GameObject.Find("Hero");
        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("getDamage");
        armatureComponent.transform.localScale = new Vector3(0.4f, 0.4f, 1);

        yield return new WaitForSecondsRealtime(3);

        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("flying");
        canBeDamaged = true;
        rb.isKinematic = false;
        isPlayedDamageAnima = false;
    }

    IEnumerator waiter() // for playing death anima
    {
        GameObject armatureComponent = GameObject.Find("Hero");
        
        armatureComponent.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("dying");
    
        yield return new WaitForSecondsRealtime(2.8f);

            SceneManager.LoadScene("Lose");

    }

    private void saveRecordScore()
    {
        int recordScore = PlayerPrefs.GetInt("recordScore");
   
        if (score > recordScore)
        {
            PlayerPrefs.SetInt("recordScore", score);
        }
    }
    private void saveCoinsAmount()
    {
        int coinsAmount = PlayerPrefs.GetInt("coinsAmount");

        PlayerPrefs.SetInt("coinsAmount", coinsAmount + score);
    }

    public void Pause()
    {
        SceneManager.LoadScene("Menu");
    }

    public void text0Main()
    {
        text0.transform.localPosition = new Vector3(15, 1, 0.0f);
        jumpPower = 5f;
    }

    IEnumerator waiterText0() // for playing death anima
    {
        text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Play("main");

        yield return new WaitForSecondsRealtime(11.25f);

        text0.GetComponent<DragonBones.UnityArmatureComponent>().animation.Stop();
        text0.transform.localPosition = new Vector3(15, 1, 0.0f);
        jumpPower = 5f;
    }
}
