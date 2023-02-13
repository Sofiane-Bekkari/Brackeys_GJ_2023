using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Sprite sp; 
    public float jumpSpeed;
    public bool touchGround;
    public ParticleSystem dropAlive;
    public ParticleSystem dropSolved;
    public ParticleSystem dropDeath;
    public TextMeshProUGUI deathText;
    public GameObject levelClear;
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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(x, y);

        Move(direction);
        // Move HORIZONTAL right / left Only
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // JUMP allowd if touchGround
        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            // By adding Velocity on Jump
            Jump(Vector2.up);
            

            //touchGround = false;
            Debug.Log("JUMP IS PRESSED");

        }
    }
    //MOVE
    void Move(Vector2 dir)
    {
        rb.AddForce(new Vector2(dir.x * speed, 0));
    }
    //JUMP
    void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
            Debug.Log("IS Grounded");
           
        }
        if (collision.gameObject.CompareTag("Seed"))
        {
            Debug.Log("You Save Seed Thank you");
            dropAlive.Stop();
            dropSolved.Play();
            levelClear.SetActive(true);
            Destroy(gameObject, 2f);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Death");
            dropAlive.Stop();
            dropDeath.Play();
            deathText.text = "DORP DIE!";
            deathText.transform.position = new Vector3(420, 220,0);
            Destroy(gameObject, 1f);
        }
    }
}
