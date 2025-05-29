using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBar : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private Rigidbody2D rb;
    private float currentRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        currentRotation = rb.rotation;
    }

    void FixedUpdate()
    {
        currentRotation += rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(currentRotation);
    }
}
