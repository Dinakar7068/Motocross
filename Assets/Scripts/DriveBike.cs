using UnityEngine;
using UnityEngine.SceneManagement;

public class BikeController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D carRB;

    [SerializeField] private float speed = 150f;

    public float maxAngularVelocity = 1000f;

    [SerializeField] private float rotationSpeed = 300f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CircleCollider2D frontTireCollider;
    [SerializeField] private CircleCollider2D backTireCollider;


    private bool isGrounded;
 

    private float moveInput;
    private float rotationInput;

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrow
        rotationInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrow
    }

    private void FixedUpdate()
    {
        bool frontGrounded = frontTireCollider.IsTouchingLayers(groundLayer);
        bool backGrounded = backTireCollider.IsTouchingLayers(groundLayer);

        float rotationModifier = 1f;

      
   
        if (frontGrounded)
        {
            rotationModifier = 0.6f; // reduce to 60% 
            if (backGrounded)
            {
                rotationModifier = 0.6f; // to 20
            }
        }
        else if (backGrounded)
        {
            rotationModifier = 0.6f; // to 60 for back alone
        }
        if (moveInput < 0)
        {
            frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        }

        if (moveInput > 0)
        {
            backTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        }

        //frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        

        
        carRB.MoveRotation(carRB.rotation + -rotationInput * rotationSpeed * rotationModifier * Time.fixedDeltaTime);

        frontTireRB.angularVelocity = Mathf.Clamp(frontTireRB.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
        backTireRB.angularVelocity = Mathf.Clamp(backTireRB.angularVelocity, -maxAngularVelocity, maxAngularVelocity);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            Debug.Log("Coin collected!");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Spike"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }

        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SaveManager.instance.money += 10;
            SaveManager.instance.Save();
        }


    }
}
