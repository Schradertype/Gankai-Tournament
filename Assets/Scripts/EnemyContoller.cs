using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves
    public float attackRange = 1f; // Distance at which the enemy will start attacking
    public float attackCooldown = 1.5f; // Time between attacks
    public int attackDamage = 10; // Amount of damage per attack

    private bool isAttacking = false; // Is the enemy currently attacking
    private float nextAttackTime = 0f; // Time until the next attack is allowed

    private Animator animator; // Reference to the Animator component
    private bool isWalking = false; // Is the enemy walking?

    private void Start()
    {
        // Get the Animator component attached to the enemy
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Calculate the distance to the player along the X-axis only
        float distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);

        // Follow the player if not attacking
        if (!isAttacking && distanceToPlayer > attackRange)
        {
            FollowPlayer();
        }
        else
        {
            // Stop walking if the enemy is in attack range
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("isWalking", false); // Switch to idle animation
            }
        }

        // If the enemy is close enough, attack the player
        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Determine the direction to move: right (1) or left (-1)
        float direction = player.position.x > transform.position.x ? 1f : -1f;

        // Move the enemy along the X-axis towards the player
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Update walking animation
        if (!isWalking)
        {
            isWalking = true;
            animator.SetBool("isWalking", true); // Play walk animation
        }

        // Flip enemy to face the correct direction
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
    }

    private void AttackPlayer()
    {
        isAttacking = true;

        // Trigger attack animation
        animator.SetTrigger("isAttacking");

        // Call damage function on the player (assuming the player has a health script)
        //PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        //if (playerHealth != null)
        //{
        //    playerHealth.TakeDamage(attackDamage);
        //}

        // Set the next time the enemy can attack
        nextAttackTime = Time.time + attackCooldown;
        Debug.Log("Attacks Player");
        // Delay the reset of the attack state to simulate attack duration
        Invoke("ResetAttack", 0.5f); // You can adjust the delay to match the attack animation length
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }
}
