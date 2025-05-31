using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundRestart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Debug.Log("Foot hit the ground - Restarting Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
