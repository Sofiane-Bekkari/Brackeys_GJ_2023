using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedBehaviors : MonoBehaviour
{
    public float scaleSize;
    public TextMeshProUGUI thanksDrop;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.localScale = new Vector2(0.7f, scaleSize);

            thanksDrop.text = "Thanks You Save Me!";

            Debug.Log("Is need to be scaled");
        }

    }
}
