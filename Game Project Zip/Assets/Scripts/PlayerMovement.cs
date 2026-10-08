using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;

    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector2 gravity =
            GravityManager.Instance.GravityVector;

        Vector2 movementDirection =
            new Vector2(-gravity.y, gravity.x);

        float movementAmount =
            input * moveSpeed;

        Vector2 velocity =
            rb.linearVelocity;

        float gravityVelocity =
            Vector2.Dot(velocity, gravity);

        rb.linearVelocity =
            movementDirection * movementAmount
            + gravity * gravityVelocity;


        float targetAngle =
            Mathf.Atan2(gravity.y, gravity.x) * Mathf.Rad2Deg - 90f;

        float currentAngle =
            rb.rotation;

        float newAngle =
            Mathf.LerpAngle(
                currentAngle,
                targetAngle,
                rotationSpeed * Time.fixedDeltaTime
            );

        rb.MoveRotation(newAngle);



        if (input != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}