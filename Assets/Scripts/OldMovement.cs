using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Sprite sp; 
    public float horizontalInput;
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
            StartCoroutine(restartAfterDelay(0.6f));

        }
        if (collision.gameObject.CompareTag("Star"))
        {
           
            Destroy(collision.gameObject);
        }
    }
    IEnumerator restartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
