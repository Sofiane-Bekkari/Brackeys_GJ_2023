using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    public float speed = 5f; // speed of the enemy movement
    public float maxY = 2.3f; // maximum Y position
    public float minY = -2.6f; // minimum Y position

    private int direction = 1; // direction of movement, 1 for up-right, -1 for down-right
    public int enemyType = 2;
    void Update()
    {
        if(enemyType == 1)
        {
            // move the enemy diagonally
            transform.Translate(new Vector3(speed * direction, speed * direction, 0) * Time.deltaTime);

            // check if the enemy has reached the maximum or minimum Y position
            if (transform.position.y >= maxY && direction == 1)
            {
                direction = -1; // change direction to down-right
            }
            else if (transform.position.y <= minY && direction == -1)
            {
                direction = 1; // change direction to up-right
            }
        }
        else if (enemyType == 2)
        {
            transform.Translate(0f, direction * speed * Time.deltaTime, 0f);

            if (transform.position.y >= maxY)
            {
                direction = -1;
            }
            else if (transform.position.y <= minY)
            {
                direction = 1;
            }
        }
        else if (enemyType == 3)
        {
  
            transform.Translate(new Vector3(speed * direction, speed * direction, 0) * Time.deltaTime);

            // check if the enemy has reached the maximum or minimum Y position
            if (transform.position.y >= maxY && direction == 1)
            {
                direction = -1; // change direction to down-right
            }
            else if (transform.position.y <= minY && direction == -1)
            {
                direction = 1; // change direction to up-right
            }
        }
    }



    }
