using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public bool change;
    public float topPos;
    public float bottomPos;

    void Update()
    {
        if (change)
        {
            moveUp();
        }
        else
        {
            moveDown();
        }
        if (transform.position.y >= topPos)
        {
            change = false;
        }
        if (transform.position.y <= bottomPos)
        {
            change = true;
        }
    }

    public void moveUp()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    public void moveDown()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
}
