using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("deleteStar", 4.0f, 0.2f);
        rb.velocity = Vector2.up * 10;
    }

    private void deleteStar()
    {
        Destroy(gameObject);
    }
}
