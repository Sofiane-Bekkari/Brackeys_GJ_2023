using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    public ParticleSystem dropAlive;
    public ParticleSystem dropDeath;
    public bool caughtPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("PLAYER IS TOUCH ME!");
            dropAlive.Stop();
            dropDeath.Play();
            caughtPlayer = true;
            FindObjectOfType<DorpSprite>().Death(caughtPlayer); // GET THIS FROM PLAYER SCRIPT
        }
    }
}
