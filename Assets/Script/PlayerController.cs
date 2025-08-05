using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour
{
    [Header("Прыжок")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private Button jumpButton;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (jumpButton != null)
            jumpButton.onClick.AddListener(Jump);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
