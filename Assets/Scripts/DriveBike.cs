using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DriveBike : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D carRB;
    [SerializeField] private float speed = 150f;
    [SerializeField] private float rotationSpeed = 300f;

    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "coin")
        {
            Debug.Log("coin hit");

            Destroy (other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carRB.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);
    }
}
