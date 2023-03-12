using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyClouds : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 7f;
    float direction = -1f;

    void Update()
    {
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stena")
            direction *= -1f;
        if (collision.gameObject.tag == "Hero")
        {
            rb2d.isKinematic = true;
            rb2d.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Collision with hero");
        }
    }
}
