using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMovement : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 10f; // Change this value to adjust the jump force.

    private bool isUp = false;
    private Rigidbody2D rb;

    //private Sprite sp; 
    public float horizontalInput;
    public float jumpSpeed;
    public bool touchGround;
    public ParticleSystem dropAlive;
    public ParticleSystem dropSolved;
    public ParticleSystem dropDeath;
    bool isGoalReached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!isGoalReached)
        {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            transform.Rotate(Vector3.up, 180f);

            isUp = !isUp;
            if (isUp)
            {
                rb.gravityScale = -1f;
                rb.velocity = new Vector2(0f, jumpForce);
                transform.Rotate(Vector3.forward, 180f);
            }
            else
            {
                rb.gravityScale = 1f;
                rb.velocity = new Vector2(0f, -jumpForce);
                transform.Rotate(Vector3.forward, -180f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Seed"))
        {
            Debug.Log("You Save Seed Thank you");
            dropAlive.Stop();
            dropSolved.Play();
            isGoalReached = true;
            gameObject.SetActive(false);
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
