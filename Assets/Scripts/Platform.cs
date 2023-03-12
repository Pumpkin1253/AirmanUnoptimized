using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 7f;
    float direction = -1f;
    public Rigidbody2D rb2d;




    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);
        transform.localScale = new Vector3(0.25f, 0.25f, 1);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stena")
            direction *= -1f;
        if (collision.gameObject.tag == "Hero")
        {
            rb2d.isKinematic = true;
            rb2d.GetComponent<PolygonCollider2D>().enabled = false;
            Debug.Log("Collision with hero");
        }
    }
}
