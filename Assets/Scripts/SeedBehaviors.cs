using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviors : MonoBehaviour
{
    public float scaleSize;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector2(0.7f, scaleSize);

            Debug.Log("Is need to be scaled");
        }

    }
}
