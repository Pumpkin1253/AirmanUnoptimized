using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicElements : MonoBehaviour
{

    public float speed = 7f;
    float direction = -1f;
    public Rigidbody2D rb2d;




    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);
        transform.localScale = new Vector3(direction, 1, 1);
    }
}
