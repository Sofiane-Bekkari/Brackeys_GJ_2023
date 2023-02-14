using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorpSprite : MonoBehaviour
{
    SpriteRenderer sr;

    //DEATH
    public void Death(bool caugth)
    {
        if (caugth)
        {
            Debug.LogWarning("IN SIDE DROP SPRITE SCRIPT");
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            /// NEED TO DISABLE OTHER BEHAVIORS AFTER THIS
            Destroy(gameObject, 3f);
        }
    }
}
