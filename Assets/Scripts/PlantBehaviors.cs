using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviors : MonoBehaviour
{
    [SerializeField] float grownSizeY;
    [SerializeField] float grownSizeX;
    public ParticleSystem grownVFX;
    bool touchable;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!touchable)
            {
                touchable = true;
                StartCoroutine(DelayVFX());

                Debug.Log("Is Plant grow");
            }
        }
        
    }

    IEnumerator DelayVFX()
    {
        grownVFX.Play();
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector2(grownSizeX, grownSizeY);
    }
   
}
