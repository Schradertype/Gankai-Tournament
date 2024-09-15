using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // SpriteRenderer referansý
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;

    // Yumruk ve Tekme Hitbox'larý
    public GameObject punchHitbox;
    public GameObject kickHitbox;

    public string enemyTag = "Enemy"; // Düþman için tag

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer referansýný al

        // Hitbox'larý baþlangýçta kapalý tutuyoruz
        punchHitbox.SetActive(false);
        kickHitbox.SetActive(false);
    }

    void Update()
    {
        HandleMovement();
        HandleAttacks();
        HandleJump();
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            // Karakter yönünü ayarla
            spriteRenderer.flipX = move < 0;

            transform.Translate(new Vector2(move * moveSpeed * Time.deltaTime, 0));
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void HandleAttacks()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("isPunching");
            StartCoroutine(ActivateHitbox(punchHitbox, 0.2f)); // Yumruk hitbox'ýný kýsa süre etkinleþtir
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("isKicking");
            StartCoroutine(ActivateHitbox(kickHitbox, 0.3f)); // Tekme hitbox'ýný kýsa süre etkinleþtir
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    // Hitbox'ý belli bir süre aktif tutup sonra devre dýþý býrakýr
    IEnumerator ActivateHitbox(GameObject hitbox, float duration)
    {
        hitbox.SetActive(true); // Hitbox'ý aktif yap
        yield return new WaitForSeconds(duration); // Belirli süre bekle
        hitbox.SetActive(false); // Hitbox'ý kapat
    }
}
