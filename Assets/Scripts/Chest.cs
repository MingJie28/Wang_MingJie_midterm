using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isInRange;
    private bool isOpen = false;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject Star;

    private void Update()
    {
        if (isInRange && Input.GetKey(KeyCode.E) && isOpen == false)
        {
            isOpen = true;
            spriteRenderer.sprite = newSprite;
        }
        if (isOpen)
        {
            InvokeRepeating("spawnStar", 0.1f, 0.2f);
        }
    }


    private void spawnStar()
    {

        Instantiate(Star, transform.position, transform.rotation);
        CancelInvoke("spawnStar");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }
}
