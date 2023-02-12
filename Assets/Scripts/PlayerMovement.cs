using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float horizontalInput;
    public float jumpSpeed;
    public bool touchGround;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //rb.velocity = new Vector2(Input.GetAxis("Jump") * speed, rb.velocity.y);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);

        // AXIS HORIZONTAL
        horizontalInput = Input.GetAxis("Horizontal");
        // Move HORIZONTAL right / left Only
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // JUMP allowd if touchGround
        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            // JUMP
            // By adding force on Jump
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);

            touchGround = false;
            Debug.Log("JUMP IS PRESSED");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
            Debug.Log("IS Grounded");
        }
    }
}
