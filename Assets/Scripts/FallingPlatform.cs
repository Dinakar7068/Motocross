using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float delayBeforeFall = 1f;
    private Rigidbody2D rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;  // Stay in place initially
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFalling && collision.gameObject.CompareTag("Player"))
        {
            isFalling = true;
            Invoke(nameof(StartFalling), delayBeforeFall);
        }
    }

    private void StartFalling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;  // Enable gravity
    }
}
